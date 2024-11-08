using System.Net;

namespace CombatCrittersSharp.exception;

/// <summary>
/// provide exception for rest error repsonses
/// </summary>
/// <param name="message"></param>
/// <param name="statusCode"></param>
/// <param name="response"></param>
public class RestException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string ResponseContent { get; }
    public HttpResponseMessage ResponseMessage { get; }

    public RestException(string message, HttpStatusCode statusCode, HttpResponseMessage response)
        : base(message)
    {
        StatusCode = statusCode;
        ResponseMessage = response;
        ResponseContent = response.Content.ReadAsStringAsync().Result; //Ensure the full content is captured for logging
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Status Code: {StatusCode}, Response Content: {ResponseContent}";
    }
}