namespace app_web_ventas.Dtos
{
    public record ProductListItemDto(
        int ProductId,
        string ProductName,
        string Category,
        string Supplier,
        string QuantityPerUnit,
        float UnitPrice,
        int UnitsInStock,
        bool Discontinued);
}
