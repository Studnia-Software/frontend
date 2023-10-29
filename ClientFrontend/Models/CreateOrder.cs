namespace ClientFrontend.Models;

public class CreateOrder
{
    public int User_id { get; set; } //z głównego id
    public int farm_id { get; set; } // od usera
    public List<Post> Posts { get; set; } //puszczać po id
}