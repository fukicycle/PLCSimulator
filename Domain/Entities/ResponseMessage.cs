namespace Domain.Entities;

public sealed class ResponseMessage
{
    public ResponseMessage(byte[] value)
    {
        Value = value;
    }
    public byte[] Value { get; }
}
