using APIClient.Models;

namespace APIClient.Request;

public class CreatePostRequest
{
    public CreatePostRequest(int farmId, string title, string productName, string productDescription, float amount,
        float quantity, bool perKg)
    {
        Farm_id = farmId;
        Title = title;
        Product_Name = productName;
        Product_Description = productDescription;
        Amount = amount;
        Quantity = quantity;
        Per_kg = perKg;
    }

    public int Farm_id { get; set; }
    public string Title { get; set; }
    public string Product_Name { get; set; }
    public string Product_Description { get; set; }
    public float Amount { get; set; }
    public float Quantity { get; set; }
    public bool Per_kg { get; set; }
}