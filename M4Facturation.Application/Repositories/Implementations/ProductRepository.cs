namespace M4Facturation.Application.Repositories.Implementations
{
    public class ProductRepository(PointSaleContext context, ICacheService cacheService, IMapper mapper) : Repository<Products>(context, cacheService, mapper), IProductRepository
    {
        
    }
}