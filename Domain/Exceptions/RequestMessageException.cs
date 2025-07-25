namespace Domain.Exceptions;

public sealed class RequestMessageException<T> : Exception
{
    public RequestMessageException(string message, T data) : base($"{message},{data}")
    {
        InvalidValue = data;
    }
    public T InvalidValue { get; }
}
