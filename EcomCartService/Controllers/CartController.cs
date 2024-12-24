using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
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
}