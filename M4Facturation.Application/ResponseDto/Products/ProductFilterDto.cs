namespace M4Facturation.Application.ResponseDto.Products
{
    public class ProductFilterDto : FilterPaged
    {
        public string? ProductName { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
}