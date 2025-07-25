namespace Domain.Strategies;

public interface IRequestMessageValidationStrategy
{
    void Validate(byte[] message);
    byte[] GetDataPart();
}
