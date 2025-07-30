using Domain.Exceptions;
using Domain.Strategies;

namespace Infrastructure.Mitsubishi.ACompatible1EFrame;

public sealed class ACompatible1EFrameValidationStrategy : IRequestMessageValidationStrategy
{
    private byte[] _message = null!;
    public void Validate(byte[] message)
    {
        if (message.Length < RequestMessageConst.MINIMUM_LENGTH)
        {
            throw new RequestMessageException<string>("Invalid data length.", BitConverter.ToString(message));
        }
        _message = message;
    }

    public byte[] GetDataValue()
    {
        var startIndex = RequestMessageConst.MINIMUM_LENGTH - 1;
        var data = _message[startIndex..];
        return data;
    }

    public byte[] GetHeaderValue()
    {
        //Headerは先頭の1バイト
        return [_message[0]];
    }
}
