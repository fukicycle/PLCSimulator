using Domain.Interfaces;

public sealed class MessageLoggerService : IMessageLoggerService
{
    public void WriteLine(string message, byte[]? data)
    {
        if (data == null)
        {
            Console.WriteLine(message);
        }
        else
        {
            Console.WriteLine($"{message} DATA:[{BitConverter.ToString(data)}]");
        }
    }
}
