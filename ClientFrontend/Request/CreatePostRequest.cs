using ClientFrontend.Models;

namespace ClientFrontend.Request;

public class CreatePostRequest
{
    public CreatePostRequest(int userId, int farmId, List<Post> posts)
    {
        User_id = userId;
        farm_id = farmId;
        Posts = posts;
    }

    public int User_id { get; set; }
    public int  farm_id { get; set; }
    public List<Post> Posts { get; set; }
}