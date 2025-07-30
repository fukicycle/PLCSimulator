using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Connections;

public sealed class RequestMessageReciever
{
    private const int MAX_QUEUE_SIZE = 10;
    private readonly Queue<RequestMessage> _requestQueues = new Queue<RequestMessage>();
    private readonly IMessageLoggerService _messageLoggerService;

    public RequestMessageReciever(IMessageLoggerService messageLoggerService)
    {
        _messageLoggerService = messageLoggerService;
    }

    public void SetStream(Stream stream)
    {
        ClientStream = stream;
    }
    public Stream? ClientStream { get; private set; }

    private bool Validate()
    {
        if (ClientStream == null)
        {
            _messageLoggerService.WriteLine("WARN: ClientStream is null.");
            return false;
        }
        return true;
    }

    public void RecieveMessage(RequestMessage requestMessage)
    {
        if (Validate())
        {
            if (_requestQueues.Count >= MAX_QUEUE_SIZE)
            {
                return;
            }
            _requestQueues.Enqueue(requestMessage);
        }
    }

    public RequestMessage? GetProcessTargetMessage(out int queueSize)
    {
        if (Validate())
        {
            queueSize = _requestQueues.Count;
            if (_requestQueues.Any())
            {
                return _requestQueues.Dequeue();
            }
        }
        queueSize = 0;
        return null;
    }
}
