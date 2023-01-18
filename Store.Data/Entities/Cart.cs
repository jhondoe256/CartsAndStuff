
public class Cart
{
    public int Id { get; set; }
    public List<Product> Products { get; set; } = new List<Product>();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

}
