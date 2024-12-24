using Microsoft.EntityFrameworkCore;

public class CartService : ICartService
{
    private readonly AppDbContext _context;

    public CartService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> UpdateCartAsync(string username, int productId, int quantity)
    {
        var cartItem = await _context.CartItems
            .FirstOrDefaultAsync(c => c.ProductId == productId && c.Username == username);

        if (cartItem == null)
        {
            if (quantity <= 0) return true;

            cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = quantity,
                Username = username
            };
            _context.CartItems.Add(cartItem);
        }
        else
        {
            if (quantity <= 0)
                _context.CartItems.Remove(cartItem);
            else
                cartItem.Quantity = quantity;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<CartSummaryResponse> GetCartSummaryAsync(string username)
    {
        var cartItems = await _context.CartItems
            .Include(c => c.Product)
            .Where(c => c.Username == username)
            .ToListAsync();

        var totalAmount = cartItems.Sum(item => item.Quantity * item.Product.Price);

        return new CartSummaryResponse
        {
            TotalAmount = totalAmount,
            Items = cartItems
        };
    }
}