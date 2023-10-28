using System.Text;
using ClientFrontend.Interfaces;

namespace ClientFrontend.Services;

public class InfrastructureService : IInfrastructureService
{
    private readonly IHttpClientFactory _client;

    public InfrastructureService(IHttpClientFactory client)
    {
        _client = client;
    }
    
    public async Task<HttpResponseMessage> Ping()
    {
        var client = _client.CreateClient("WarzywaClient");
        var request = new HttpRequestMessage(HttpMethod.Get, new Uri(client.BaseAddress + "test/ping"));
        var response = await client.SendAsync(request);
        return response;
    }
}