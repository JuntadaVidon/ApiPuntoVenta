namespace M4Facturation.Application.ResponseDto.Products
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string? Category { get; set; }

        public string? Supplier { get; set; }

        public string? QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? UnitsInStock { get; set; }

        public int? UnitsOnOrder { get; set; }

        public int? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

    }
}