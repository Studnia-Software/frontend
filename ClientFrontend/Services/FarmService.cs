using ClientFrontend.Interfaces;
using APIClient.Models;

namespace ClientFrontend.Services;

public class FarmService : IFarmService
{
    private readonly IHttpClientFactory _clientFactory;
    public FarmService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;

    }
    public async Task<HttpResponseMessage> GetFarms()
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.GetAsync(client.BaseAddress + "api/get-farms/");

        return response;
    }

    public async Task<HttpResponseMessage> GetFarm(int id)
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.GetAsync(client.BaseAddress + $"api/get-farm-posts/{id}");
        
        return response;
    }

    public async Task<HttpResponseMessage> CreateFarm(CreateFarm dto)
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.PostAsJsonAsync(client.BaseAddress + "", dto);

        return response;
    }

    public async Task<HttpResponseMessage> DeleteFarm(int id)
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.DeleteAsync(client.BaseAddress + $"api/get-farm/{id}");

        return response;
    }
}