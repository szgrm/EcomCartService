public class CartSummaryResponse
{
    public decimal TotalAmount { get; set; }
    public List<CartItem> Items { get; set; }
}