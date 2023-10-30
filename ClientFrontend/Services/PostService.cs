using System.Runtime.InteropServices.JavaScript;
using System.Text;
using ClientFrontend.Interfaces;
using APIClient.Models;
using Newtonsoft.Json;

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
        var serializedString = JsonConvert.SerializeObject(dto);
        Console.WriteLine(serializedString);
        var client = _ClientFactory.CreateClient("WarzywaClient");
        HttpRequestMessage msg = new(HttpMethod.Post, client.BaseAddress + "api/store/");
        msg.Content = new StringContent(serializedString, Encoding.UTF8, "application/json");

        var responseStr = await client.SendAsync(msg);
        return responseStr;
    }
}