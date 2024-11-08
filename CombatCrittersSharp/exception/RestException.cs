using System.Net;

namespace CombatCrittersSharp.exception;

/// <summary>
/// provide exception for rest error repsonses
/// </summary>
/// <param name="message"></param>
/// <param name="statusCode"></param>
/// <param name="response"></param>
public class RestException(string message, HttpStatusCode statusCode, HttpResponseMessage response) : CombatCrittersException(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
    public string? ResponseContent { get; } = response.Content.ReadAsStringAsync().Result;

    public override string ToString()
    {
        return $"{base.ToString()}, Status Code: {StatusCode}, Response Content: {ResponseContent ?? "No response content"}";
    }
}