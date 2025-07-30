using Domain.Interfaces;
using Infrastructure.Services;

namespace Infrastructure;

public static class ResponseDataServiceFactory
{
    public static IResponseDataService Create(RegisterType type)
    {
        switch (type)
        {
            case RegisterType.BIT:
                return new BitResponseDataService();
            case RegisterType.WORD:
                return new WordResponseDataService();
            default:
                throw new NotSupportedException($"Your request data is invalid.{type}");
        }
    }
}
