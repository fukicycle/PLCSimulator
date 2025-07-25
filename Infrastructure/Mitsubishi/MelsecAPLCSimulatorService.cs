using Domain.Interfaces;
using Infrastructure.Connections;

namespace Infrastructure.Mitsubishi;

public sealed class MelsecAPLCSimulatorService : IPLCSimulatorService, IDisposable
{
    private readonly TcpServer _tcpServer;
    private readonly RequestMessageReciever _requestMessageReciever = new RequestMessageReciever();
    private readonly IMessageHandlingService _messageHandlingService;
    private readonly IMessageLoggerService _messageLoggerService;
    public MelsecAPLCSimulatorService(
        IMessageLoggerService messageLoggerService,
        IMessageHandlingService messageHandlingService)
    {
        _tcpServer = new TcpServer(messageLoggerService);
        _messageHandlingService = messageHandlingService;
        _messageLoggerService = messageLoggerService;
    }

    public void StartPLCSimulator(int port)
    {
        _tcpServer.Start(port, PLCType.MelsecA, _requestMessageReciever);
        Task.Run(async () =>
        {
            while (true)
            {
                var requestMessage = _requestMessageReciever.GetProcessTargetMessage(out int currentSize);
                if (requestMessage != null)
                {
                    _messageHandlingService.HandleMessage(requestMessage);
                    _messageLoggerService.WriteLine("Queue processed.");
                    _messageLoggerService.WriteLine($"Queue remain size: {currentSize}");
                    await Task.Delay(250);
                }
            }
        });
    }

    public void Dispose()
    {
        _tcpServer.Dispose();
    }
}
