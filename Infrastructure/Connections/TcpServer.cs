using System.Net;
using System.Net.Sockets;
using Domain.Interfaces;

namespace Infrastructure.Connections;

public sealed class TcpServer : IDisposable
{
    private readonly IMessageLoggerService _messageLoggerService;
    private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    public TcpServer(IMessageLoggerService messageLoggerService)
    {
        _messageLoggerService = messageLoggerService;
    }
    public void Dispose()
    {
        _cancellationTokenSource.Cancel();
    }

    public void Start(int port, PLCType plcType, RequestMessageReciever requestMessageReciever)
    {
        Task.Run(async () =>
        {
            using var listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            _messageLoggerService.WriteLine($"Waiting for connection on port:{port}");

            while (!_cancellationTokenSource.IsCancellationRequested)
            {
                var client = await listener.AcceptTcpClientAsync();
                var endPoint = (IPEndPoint?)client.Client.RemoteEndPoint;
                _messageLoggerService.WriteLine($"Connected! Remote:{endPoint?.Address}:{endPoint?.Port}");

                _ = HandleClientAsync(client, port, plcType, requestMessageReciever);
            }
        }, _cancellationTokenSource.Token);
    }

    private async Task HandleClientAsync(TcpClient client, int port, PLCType plcType, RequestMessageReciever requestMessageReciever)
    {
        try
        {
            using var stream = client.GetStream();
            byte[] buffer = new byte[256];
            while (true)
            {
                int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (read <= 0) break;

                var request = new byte[read];
                Array.Copy(buffer, 0, request, 0, read);
                _messageLoggerService.WriteLine($"[{port}] Recieved.", request);
                var requestMessage = RequestMessageFactory.Create(plcType, request);
                requestMessageReciever.RecieveMessage(requestMessage);
            }
            _messageLoggerService.WriteLine($"[{port}] Disconnected.");
            client.Close();
        }
        catch (Exception ex)
        {
            _messageLoggerService.WriteLine(ex.Message);
        }
        finally
        {
            client.Dispose();
        }
    }
}
