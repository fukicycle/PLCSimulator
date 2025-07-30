using System.Threading.Tasks;
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
    public async Task<ResponseMessage> HandleMessageAsync(RequestMessage message, Stream stream)
    {
        var response = _requestMessageProcessorService.ProcessRequest(message);
        await _responseMessageSender.SendMessageAsync(response, stream);
        return response;
    }
}
