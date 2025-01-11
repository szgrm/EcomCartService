using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/cart")]
public class CartController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("update")]
    public async Task<ActionResult> UpdateCart([FromBody] CartUpdateRequest request)
    {
        if (string.IsNullOrEmpty(request.Username))
        {
            return BadRequest("Username is required");
        }

        var result = await _cartService.UpdateCartAsync(
            request.Username,
            request.ProductId,
            request.Quantity);

        return result ? Ok() : BadRequest();
    }

    [HttpGet("summary/{username}")]
    public async Task<ActionResult<CartSummaryResponse>> GetCartSummary(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            return BadRequest("Username is required");
        }

        return await _cartService.GetCartSummaryAsync(username);
    }

    [HttpDelete("{username}/{productId}")]
    public async Task<ActionResult> DeleteCartItem(string username, int productId)
    {
        if (string.IsNullOrEmpty(username))
        {
            return BadRequest("Username is required");
        }

        var result = await _cartService.DeleteCartItemAsync(username, productId);
        return result ? Ok() : NotFound();
    }

    [HttpDelete("{username}")]
    public async Task<ActionResult> EmptyCart(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            return BadRequest("Username is required");
        }

        var result = await _cartService.EmptyCartAsync(username);
        return result ? Ok() : NotFound();
    }
}