namespace ClientFrontend.Models;

public class Order
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Product Product { get; set; }
}