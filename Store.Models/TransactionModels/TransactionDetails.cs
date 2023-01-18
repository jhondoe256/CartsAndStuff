
public class TransactionDetails
{
    public int Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public CustomerListItem Customer { get; set; }
    public CartListItem Cart { get; set; }
}
