using System.Net;

namespace CombatCrittersSharp.rest.exception;

public class RestException(string message, HttpStatusCode statusCode, HttpResponseMessage response)
    : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
    public HttpResponseMessage ResponseMessage { get; } = response;
}