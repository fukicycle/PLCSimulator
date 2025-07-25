using Domain.Entities;

namespace Domain.Interfaces;

public interface IMessageHandlingService
{
    void HandleMessage(RequestMessage message);
}
