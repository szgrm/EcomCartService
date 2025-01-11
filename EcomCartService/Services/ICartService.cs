public interface ICartService
{
    Task<bool> UpdateCartAsync(string username, int productId, int quantity);
    Task<CartSummaryResponse> GetCartSummaryAsync(string username);
    Task<bool> DeleteCartItemAsync(string username, int productId);
}