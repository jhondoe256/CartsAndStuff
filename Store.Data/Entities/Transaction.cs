
public class Transaction
{
    public int Id { get; set; }

    // public DateTime TransactionDate { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }


    public int CartId { get; set; }
    public Cart Cart { get; set; }
}
