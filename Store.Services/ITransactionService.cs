
public interface ITransactionService
{
    Task<bool> AddTransaction(TransactionCreate model);
    Task<TransactionDetails> GetTransaction(int id);
    Task<List<TransactionListItem>> GetTransactions();
}
