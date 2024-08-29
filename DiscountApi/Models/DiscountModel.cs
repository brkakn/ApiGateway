namespace DiscountApi.Models;

public record DiscountModel
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal DiscountAmount { get; set; }
}
