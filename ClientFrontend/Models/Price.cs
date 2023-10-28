namespace ClientFrontend.Models;

public class Price
{
    public int Id { get; set; }
    public int? Amount { get; set; }
    public int? Quantity { get; set; }
    public bool per_kg { get; set; }
}