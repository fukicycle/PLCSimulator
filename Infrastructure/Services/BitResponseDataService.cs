using Domain.Interfaces;

namespace Infrastructure.Services;

public sealed class BitResponseDataService : IResponseDataService
{
    public byte[] CreateResponseData(int requestSize)
    {
        if (requestSize % 2 != 0)
        {
            return Array.Empty<byte>();
        }
        var responseSize = requestSize / 2;
        var responseData = new byte[responseSize];
        for (int i = 0; i < responseSize; i++)
        {
            var value = Random.Shared.Next(0, 4);
            responseData[i] = (byte)value;
        }
        return responseData;
    }
}
