
public class CartListItem
{
    public int Id { get; set; }
    public List<ProductListItem> Products { get; set; } = new List<ProductListItem>();
}
