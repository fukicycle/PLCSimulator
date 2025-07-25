using System;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Mitsubishi.ACompatible1EFrame;

public sealed class ACompatible1EFrameRequestMessageProcessorService : IRequestMessageProcessorService
{
    public ResponseMessage ProcessRequest(RequestMessage requestMessage)
    {
        return new ResponseMessage();
    }
}
