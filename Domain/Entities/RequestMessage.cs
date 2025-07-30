using Domain.Strategies;

namespace Domain.Entities;

public sealed class RequestMessage
{
    public RequestMessage(
        byte[] value,
        IRequestMessageValidationStrategy requestMessageValidationStrategy)
    {
        requestMessageValidationStrategy.Validate(value);
        HeaderValue = requestMessageValidationStrategy.GetHeaderValue();
        Value = value;
        Length = value.Length;
        DataValue = requestMessageValidationStrategy.GetDataValue();
        DataLength = DataValue.Length;
    }
    public byte[] HeaderValue { get; set; }
    public byte[] Value { get; }
    public int Length { get; }
    public byte[] DataValue { get; }
    public int DataLength { get; }
}