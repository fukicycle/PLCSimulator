using Domain.Entities;

namespace Domain.Interfaces;

public interface IMessageHandlingService
{
    Task<ResponseMessage> HandleMessageAsync(RequestMessage message, Stream stream);
}
