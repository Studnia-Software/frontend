﻿using ClientFrontend.Interfaces;
using ClientFrontend.Models;

namespace ClientFrontend.Services;

public class PostService : IPostService
{
    public readonly IHttpClientFactory _ClientFactory;
    public PostService(IHttpClientFactory clientFactory)
    {
        _ClientFactory = clientFactory;
    }
    public async Task<HttpResponseMessage> CreatePost(CreatePost dto)
    {
        var client = _ClientFactory.CreateClient("WarzywaClient");
        var rnd = new Random();
        var result = await client.PostAsJsonAsync<CreatePost>(client.BaseAddress + $"api/store", dto);
        return result;
    }
}