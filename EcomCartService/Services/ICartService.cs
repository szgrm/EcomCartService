public interface ICartService
{
    Task<bool> UpdateCartAsync(string username, int productId, int quantity);
    Task<CartSummaryResponse> GetCartSummaryAsync(string username);
}