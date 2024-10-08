using System.Text;
using System.Text.Json;
using CombatCrittersSharp.exception;

namespace CombatCrittersSharp.rest;

/// <summary>
/// provide rest methods implementation
/// </summary>
public class Rest : IRest
{
    private readonly HttpClient _httpClient;
    
    public Rest(string baseUrl)
    {
        this._httpClient = new HttpClient {BaseAddress = new Uri(baseUrl)};
    }
    public async Task<HttpResponseMessage> Put(string endpoint, object body)
    {
        var res = await this._httpClient.PutAsync(endpoint, ObjectToContent(body));
        CheckResponse(res);
        return res;
    }
    public async Task<HttpResponseMessage> Patch(string endpoint, object body)
    {
        var res = await this._httpClient.PatchAsync(endpoint, ObjectToContent(body));
        CheckResponse(res);
        return res;
    }
    public async Task<HttpResponseMessage> Post(string endpoint, object body)
    {
        var res = await this._httpClient.PostAsync(endpoint, ObjectToContent(body));
        CheckResponse(res);
        return res;
    }

    public async Task<HttpResponseMessage> Get(string endpoint)
    {
        
        var res = await this._httpClient.GetAsync(endpoint);
        CheckResponse(res);
        return res;
    }
    public async Task<HttpResponseMessage> Delete(string endpoint)
    {
        
        var res = await this._httpClient.DeleteAsync(endpoint);
        CheckResponse(res);
        return res;
    }

    private static StringContent ObjectToContent(object obj)
    {
        return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
    }

    private static void CheckResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new RestException("Request failed with status code " + response.StatusCode, response.StatusCode, response);
        };
    }
}