namespace Domain.Interfaces;

public interface IMessageLoggerService
{
    void WriteLine(string message, byte[]? data = null);
}
