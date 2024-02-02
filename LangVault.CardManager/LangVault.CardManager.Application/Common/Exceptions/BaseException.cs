namespace LangVault.CardManager.Application.Common.Exceptions;
public class BaseException : Exception
{
    public int? Code { get; }
    public HttpStatusCode StatusCode { get; }

    public BaseException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        int? code = null) : base(message)
    {
        StatusCode = statusCode;
        Code = code;
    }
    public BaseException(
        string message,
        Exception innerException,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        int? code = null) : base(message, innerException)
    {
        StatusCode = statusCode;
        Code = code;
    }

    public BaseException(
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        int? code = null) : base()
    {
        StatusCode = statusCode;
        Code = code;
    }
}
