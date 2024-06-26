namespace M4Facturation.Application.AutoMapper.ProductsMappings
{
    public class AutoMapperProfileProduct : Profile
    {
        public AutoMapperProfileProduct()
        {
            CreateMap<Products, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName))
                .ForMember(dest => dest.Supplier, opt => opt.MapFrom(src => src.Supplier.SupplierName))
                .ReverseMap();
            CreateMap<Products, ProductPostUpdate>().ReverseMap();
        }
    }
}