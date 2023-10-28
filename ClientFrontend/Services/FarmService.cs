using ClientFrontend.Endpoints;
using ClientFrontend.Interfaces;
using ClientFrontend.Models;

namespace ClientFrontend.Services;

public class FarmService : IFarmService
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly ApiEndpoints _api;
    public FarmService(IHttpClientFactory clientFactory, ApiEndpoints api)
    {
        _clientFactory = clientFactory;
        _api = api;
    }
    public async Task<HttpResponseMessage> GetFarms()
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.GetAsync(client.BaseAddress + _api.Farm);

        return response;
    }

    public async Task<HttpResponseMessage> GetFarm(int id)
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.GetAsync(client.BaseAddress + _api.GetFarmPosts + $"{id}");

        return response;
    }

    public async Task<HttpResponseMessage> CreateFarm(CreateFarm dto)
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.PostAsJsonAsync(client.BaseAddress + _api.Farm, dto);

        return response;
    }

    public async Task<HttpResponseMessage> DeleteFarm(int id)
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.DeleteAsync(client.BaseAddress + $"api/get-farm/{id}");

        return response;
    }
}