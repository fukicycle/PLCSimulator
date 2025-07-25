using Domain.Strategies;

namespace Domain.Entities;

public sealed class RequestMessage
{
    public RequestMessage(
        byte[] value,
        IRequestMessageValidationStrategy requestMessageValidationStrategy)
    {
        requestMessageValidationStrategy.Validate(value);
        Value = value;
        Length = value.Length;
        PartOfData = requestMessageValidationStrategy.GetDataPart();
        DataLength = PartOfData.Length;
    }
    public byte[] Value { get; }
    public int Length { get; }
    public byte[] PartOfData { get; }
    public int DataLength { get; }
}