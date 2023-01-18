
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Cart> Carts { get; set; } = new List<Cart>();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

}
