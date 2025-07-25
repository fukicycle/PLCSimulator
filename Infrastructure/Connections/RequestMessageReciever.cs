using Domain.Entities;

namespace Infrastructure.Connections;

public sealed class RequestMessageReciever
{
    private const int MAX_QUEUE_SIZE = 10;
    private readonly Queue<RequestMessage> _requestQueues = new Queue<RequestMessage>();
    public void RecieveMessage(RequestMessage requestMessage)
    {
        if (_requestQueues.Count >= MAX_QUEUE_SIZE)
        {
            return;
        }
        _requestQueues.Enqueue(requestMessage);
    }

    public RequestMessage? GetProcessTargetMessage(out int queueSize)
    {
        queueSize = _requestQueues.Count;
        if (_requestQueues.Any())
        {
            return _requestQueues.Dequeue();
        }
        return null;
    }
}
