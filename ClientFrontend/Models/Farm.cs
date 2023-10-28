namespace ClientFrontend.Models;

public class Farm
{
    public int Id { get; set; }
    public int User_Id { get; set; }
    public string Name { get; set; }

    public List<Post> Posts { get; set; }
}