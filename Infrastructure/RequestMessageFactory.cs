using Domain.Entities;
using Infrastructure.Mitsubishi.ACompatible1EFrame;

namespace Infrastructure;

public static class RequestMessageFactory
{
    public static RequestMessage Create(PLCType plcType, byte[] message)
    {
        switch (plcType)
        {
            case PLCType.MelsecA:
                var strategy = new ACompatible1EFrameValidationStrategy();
                return new RequestMessage(message, strategy);
        }
        throw new NotImplementedException();
    }
}
