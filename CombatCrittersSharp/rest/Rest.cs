using System.Text;
using System.Text.Json;

namespace CombatCrittersSharp.rest;

public class Rest : IRest
{
    private readonly HttpClient _httpClient;
    
    public Rest(string baseUrl)
    {
        this._httpClient = new HttpClient {BaseAddress = new Uri(baseUrl)};
    }
    public async Task<HttpResponseMessage> Post(string endpoint, object body)
    {
        var res = await this._httpClient.PostAsync(endpoint, ObjectToContent(body));
        return res;
    }

    public Task<HttpResponseMessage> Get(string endpoint)
    {
        return this._httpClient.GetAsync(endpoint);
    }

    private static StringContent ObjectToContent(object obj)
    {
        return new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");
    }
}