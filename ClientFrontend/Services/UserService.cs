﻿using ClientFrontend.Interfaces;
using ClientFrontend.Models;

namespace ClientFrontend.Services;

public class UserService : IUserService
{
    private readonly IHttpClientFactory _clientFactory;

    public UserService(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<HttpResponseMessage> GetUser(int id)
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.GetAsync(client.BaseAddress + $"api/get-user/{id}");
        return response;
    }

    public async Task<HttpResponseMessage> CreateUser(CreateUser dto)
    {
        var client = _clientFactory.CreateClient("WarzywaClient");
        var response = await client.PostAsJsonAsync(client.BaseAddress + $"", dto);
        return response;
    }
}