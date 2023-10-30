using System;
using System.Text;
using Newtonsoft.Json;
namespace tests;

public class PostTest
{
    public PostTest(int farmId, string title, string productName, string productDescription, float amount, float quantity, bool perkg)
    {
        var dto = new CreatePost1
        {
            Farm_id = farmId,
            Title = title,
            Product_Name = productName,
            Product_Description = productDescription,
            Amount = amount,
            Quantity = quantity,
            Per_kg = perkg
        };
        var serializedString = JsonConvert.SerializeObject(dto);
        Console.WriteLine(serializedString);
        var client = new HttpClient();
        HttpRequestMessage msg = new(HttpMethod.Post, client.BaseAddress + "http://localhost:8000/api/store/");
        msg.Content = new StringContent(serializedString, Encoding.UTF8, "application/json");

        var responseStr =  client.Send(msg);
    }
}