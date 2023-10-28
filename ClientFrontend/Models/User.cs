namespace ClientFrontend.Models;

public class User
{
    public int Id { get; set; }
    public int role { get; set; }
    
    public Farm Farm { get; set; }
}