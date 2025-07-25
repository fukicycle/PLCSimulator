using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Connections;

namespace Application.Services;

public sealed class MessageHandlingService : IMessageHandlingService
{
    private readonly IRequestMessageProcessorService _requestMessageProcessorService;
    private readonly ResponseMessageSender _responseMessageSender = new ResponseMessageSender();

    public MessageHandlingService(
        IRequestMessageProcessorService requestMessageProcessorService)
    {
        _requestMessageProcessorService = requestMessageProcessorService;
    }
    public void HandleMessage(RequestMessage message)
    {
        var response = _requestMessageProcessorService.ProcessRequest(message);
        _responseMessageSender.SendMessage(response);
    }
}
