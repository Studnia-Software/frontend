namespace ClientFrontend.Models;

public class CreatePost
{
    public int Farm_id { get; set; }
    public string Title { get; set; }
    public string Product_Name { get; set; }
    public string Product_Description { get; set; }
    public float Amount { get; set; }
    public float Quantity { get; set; }
    public bool Per_kg { get; set; }
}