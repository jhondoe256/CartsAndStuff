
using Microsoft.EntityFrameworkCore;

public class CartService : ICartService
{
    private StoreContext _context;

    public CartService(StoreContext context)
    {
        _context = context;
    }

    public async Task<bool> AddToCart(CartCreate model)
    {
        var entity = new Cart();

        if (model.ProductsIds.Count() > 0)
        {
            foreach (var id in model.ProductsIds)
            {
                var product = await _context.Products.FindAsync(id);
                if (product is null) return false;

                entity.Products.Add(product);
            }
        }

        await _context.Carts.AddAsync(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<CartDetails> CartDetails(int id)
    {
        var cart = await _context
        .Carts
        .Include(c => c.Products)
        .FirstOrDefaultAsync(x => x.Id == id);

        if (cart is null) return null;

        return new CartDetails
        {
            Id = cart.Id,
            Products = cart.Products.Select(p => new ProductListItem
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price
            }).ToList(),

        };
    }
}
