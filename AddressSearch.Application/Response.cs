using System.Net;

namespace AddressSearch.Application;

public class Response
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public object? Paylod { get; set; }

    public Response(HttpStatusCode statusCode, bool isSuccess, object? payload = null)
    {
        StatusCode = statusCode;
        IsSuccess = isSuccess;
        Paylod = payload;
    }
}