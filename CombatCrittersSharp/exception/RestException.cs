using System.Net;

namespace CombatCrittersSharp.exception;

/// <summary>
/// provide exception for rest error repsonses
/// </summary>
/// <param name="message"></param>
/// <param name="statusCode"></param>
/// <param name="response"></param>
public class RestException(string message, HttpStatusCode statusCode, HttpResponseMessage response) : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
    public HttpResponseMessage ResponseMessage { get; } = response;
}