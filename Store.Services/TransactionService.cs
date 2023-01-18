
using Microsoft.EntityFrameworkCore;

public class TransactionService : ITransactionService
{
    private StoreContext _context;

    public TransactionService(StoreContext context)
    {
        _context = context;
    }

    public async Task<bool> AddTransaction(TransactionCreate model)
    {
        var entity = new Transaction
        {
            CartId = model.CartId,
            CustomerId = model.CustomerId,
        };

        await _context.Transactions.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<TransactionDetails> GetTransaction(int id)
    {
        var transactionInDb = await _context.Transactions
        .Include(t => t.Customer)
        .Include(t => t.Cart)
        .ThenInclude(t => t.Products)
        .FirstOrDefaultAsync(x => x.Id == id);

        if (transactionInDb is null) return null;

        return new TransactionDetails
        {
            Id = transactionInDb.Id,
            Cart = new CartListItem
            {
                Id = transactionInDb.Cart.Id,
                Products = transactionInDb.Cart.Products.Select(p => new ProductListItem
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                }).ToList()
            },
            Customer = new CustomerListItem
            {
                Id = transactionInDb.Customer.Id,
                Name = transactionInDb.Customer.Name
            }
        };
    }

    public async Task<List<TransactionListItem>> GetTransactions()
    {
        return await _context.Transactions.Select(t=> new TransactionListItem{
            Id=t.Id,
            CartId=t.Cart.Id,
            CustomerName=t.Customer.Name
        }).ToListAsync();
    }
}
