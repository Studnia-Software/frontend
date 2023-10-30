using API.Models;

namespace APIClient.Request;

public class CreateOrderRequest
{
    public CreateOrderRequest(int userId, int farmId, List<Post>? posts)
    {
        User_id = userId;
        Farm_id = farmId;
        Posts = posts;
    }
    public int User_id { get; set; } //z głównego id
    public int Farm_id { get; set; } // od usera
    public  List<Post>? Posts { get; set; } //puszczać po id
}