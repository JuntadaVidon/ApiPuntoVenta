namespace M4Facturation.Application.Services.Implementations
{
    public class ProductService(IUnitOfWork _unitOfWork) : BaseService, IProductService
    {
        public async Task<OperationResponse<List<ProductDto>>> GetFilteredProductsAsync(ProductFilterDto filter)
        {
            //Se obtiene el repositorio de productos para realizar la consulta
            var repositoryProduct = _unitOfWork.GetRepository<IProductRepository>();

            // Se utliiza PredicateBuilder para construir la consulta de manera dinámica de la librería LinqKit
            var predicate = PredicateBuilder.New<Products>(true);

            if (!string.IsNullOrEmpty(filter.ProductName))
            {
                predicate = predicate.And(p => p.ProductName.Contains(filter.ProductName));
            }

            if (filter.MinPrice.HasValue)
            {
                predicate = predicate.And(p => p.UnitPrice >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                predicate = predicate.And(p => p.UnitPrice <= filter.MaxPrice.Value);
            }

            if (filter.CategoryId.HasValue)
            {
                predicate = predicate.And(p => p.CategoryId == filter.CategoryId.Value);
            }

            if (filter.SupplierId.HasValue)
            {
                predicate = predicate.And(p => p.SupplierId == filter.SupplierId.Value);
            }

            //Se incluyen las propiedades de navegación de la entidad Productos
            var includeProperties = new Expression<Func<Products, object>>[]
            {
                p => p.Category,
                p => p.Supplier
            };

            var result = await repositoryProduct.GetPagedDataAsync<ProductDto>(
                filter.Page,
                filter.PageSize,
                predicate,
                includeProperties
            );

            return result;
        }
    }
}