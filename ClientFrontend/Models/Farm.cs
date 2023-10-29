namespace ClientFrontend.Models;

public class Farm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Delivery_Days { get; set; }
    public string Delivery_Time { get; set; }
    public Location Location { get; set; }

    public List<Post> Posts { get; set; }
    
}