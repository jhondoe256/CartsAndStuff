
public interface ICartService
{
    Task<bool> AddToCart(CartCreate model);
    Task<CartDetails> CartDetails(int id);
}
