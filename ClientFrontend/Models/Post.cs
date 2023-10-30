namespace APIClient.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Product_id { get; set; }
    public int Price_id { get; set; }
    public int farm_id { get; set; }

    public Farm? Farm { get; set; }
    public Product? Product { get; set; }
    public Price? Price { get; set; }
}