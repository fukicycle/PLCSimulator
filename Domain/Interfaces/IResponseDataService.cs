using System;

namespace Domain.Interfaces;

public interface IResponseDataService
{
    byte[] CreateResponseData(int requestSize);
}
