using Domain.Interfaces;

namespace Infrastructure.Services;

public sealed class WordResponseDataService : IResponseDataService
{
    public byte[] CreateResponseData(int requestSize)
    {
        //1ワード = 2バイト = 16ビット
        var responseSize = requestSize * 2;
        var responseData = new byte[responseSize];
        int lowByteValue = 1;
        int highByteValue = 0;
        for (int i = 0; i < responseSize; i += 2)
        {
            responseData[i] = (byte)lowByteValue;
            responseData[i + 1] = (byte)highByteValue;
            lowByteValue++;
            if (lowByteValue == 256)
            {
                highByteValue++;
                lowByteValue = 1;
            }
        }
        return responseData;
    }
}
