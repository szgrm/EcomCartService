using System.ComponentModel.DataAnnotations;

public class Product
{
    public int Id { get; set; }

    [MaxLength(100)] public required string Title { get; set; }
    [MaxLength(500)] public required string Description { get; set; }
    [MaxLength(100)] public required string Category { get; set; }
    [MaxLength(100)] public required string Brand { get; set; }
    [MaxLength(100)] public required string Sku { get; set; }
    public double Price { get; set; }
    public double DiscountPercentage { get; set; }
    public double Rating { get; set; }
    public int Stock { get; set; }
    public int Weight { get; set; }
    public int MinimumOrderQuantity { get; set; }
    public List<string>? Images { get; set; }
    [MaxLength(200)] public string? Thumbnail { get; set; }
}