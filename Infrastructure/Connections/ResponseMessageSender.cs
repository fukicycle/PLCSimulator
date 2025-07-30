using Domain.Entities;

namespace Infrastructure.Connections;

public sealed class ResponseMessageSender
{
    public async Task SendMessageAsync(ResponseMessage message, Stream stream)
    {
        await stream.WriteAsync(message.Value, 0, message.Value.Length);
    }
}
