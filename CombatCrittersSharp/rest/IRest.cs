namespace CombatCrittersSharp.rest;

public interface IRest
{
    /// <summary>
    /// Post the given body to the endpoint
    /// </summary>
    /// <param name="endpoint">endpoint to post to</param>
    /// <param name="body">body for the request</param>
    /// <returns>response body</returns>
    Task<HttpResponseMessage> Post(string endpoint, object body);
    
    /// <summary>
    /// GET the endpoint
    /// </summary>
    /// <param name="endpoint">endpoint to GET</param>
    /// <returns>response from the endpoint</returns>
    Task<HttpResponseMessage> Get(string endpoint);
}