namespace M4Facturation.Application.AutoMapper.Products
{
    public class AutoMapperProfileProduct : Profile
    {
        public AutoMapperProfileProduct()
        {
            CreateMap<Domain.Models.Products, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier.SupplierName))
                .ReverseMap();
        }
    }
}