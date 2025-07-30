using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Mitsubishi.ACompatible1EFrame;

public sealed class ACompatible1EFrameRequestMessageProcessorService : IRequestMessageProcessorService
{
    public ResponseMessage ProcessRequest(RequestMessage requestMessage)
    {
        var header = requestMessage.HeaderValue[0];
        var headerObj = ACompatible1EFrameRequestHeader.Create(header);
        var responseHeaderObj = GetResponseHeaderFromRequestHeader(headerObj);
        byte finishCode = 0x00;
        var requestSize = (int)requestMessage.Value[RequestMessageConst.DEVICE_COUNT];
        var data = ResponseDataServiceFactory.Create(responseHeaderObj.RegisterType).CreateResponseData(requestSize);
        var responseData = new byte[] { responseHeaderObj.Value, finishCode }.Concat(data).ToArray();
        return new ResponseMessage(responseData);
    }

    private ACompatible1EFrameResponseHeader GetResponseHeaderFromRequestHeader(ACompatible1EFrameRequestHeader header)
    {
        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_BULK_READ_BIT)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_BULK_READ_BIT;
        }

        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_BULK_READ_WORD)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_BULK_READ_WORD;
        }

        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_BULK_WRITE_BIT)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_BULK_WRITE_BIT;
        }

        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_BULK_WRITE_WORD)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_BULK_WRITE_WORD;
        }

        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_MONITOR_BIT)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_MONITOR_BIT;
        }

        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_MONITOR_WORD)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_MONITOR_WORD;
        }

        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_MONITOR_REGISTER_BIT)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_MONITOR_REGISTER_BIT;
        }

        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_MONITOR_REGISTER_WORD)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_MONITOR_REGISTER_WORD;
        }

        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_TEST_WRITE_BIT)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_TEST_WRITE_BIT;
        }

        if (header == ACompatible1EFrameRequestHeader.DEVICE_MEM_TEST_WRITE_WORD)
        {
            return ACompatible1EFrameResponseHeader.DEVICE_MEM_TEST_WRITE_WORD;
        }
        throw new NotSupportedException($"Your request is invalid.{header.Value}");
    }
}
