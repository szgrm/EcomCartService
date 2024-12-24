public interface ICartService
{
    Task<bool> UpdateCartAsync(string username, int productId, int quantity);
    Task<List<CartItem>> GetCartSummaryAsync(string username);
} 