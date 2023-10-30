using ClientFrontend.Interfaces;
using APIClient.Models;

namespace ClientFrontend.Services;

public class OrderService : IOrderService
{
    private readonly IHttpClientFactory _clientFactory;

    public OrderService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }
    public async Task<HttpResponseMessage> CreateOrder(CreateOrder dto)
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var result = await client.PostAsJsonAsync<CreateOrder>(client.BaseAddress + "api/create-order", dto);
        return result;
    }
}