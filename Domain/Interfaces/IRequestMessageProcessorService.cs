using Domain.Entities;

namespace Domain.Interfaces;

public interface IRequestMessageProcessorService
{
    ResponseMessage ProcessRequest(RequestMessage requestMessage);
}
