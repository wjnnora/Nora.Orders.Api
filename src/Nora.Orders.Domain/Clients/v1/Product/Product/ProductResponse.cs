namespace Nora.Orders.Domain.Clients.v1.Product.Product;

public sealed class ProductResponse
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Value { get; set; }
    public int CategoryId { get; set; }
    public ProductCategoryResponse Category { get; set; }
}