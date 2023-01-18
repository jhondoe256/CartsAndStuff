
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int InventoryCount { get; set; } = 100;
    public List<Cart> Carts { get; set; } = new List<Cart>();
}
