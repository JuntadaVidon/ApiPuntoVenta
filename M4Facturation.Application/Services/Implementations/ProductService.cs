using M4Facturation.Application.Validators;

namespace M4Facturation.Application.Services.Implementations
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper mapper, ProductValidator _validator)
        : BaseService(mapper), IProductService
    {
        private readonly IProductRepository _repositoryProduct = _unitOfWork.GetRepository<IProductRepository>();

        public async Task<OperationResponse<List<ProductDto>>> GetFilteredProductsAsync(ProductFilterDto filter)
        {
            // Se utliiza PredicateBuilder para construir la consulta de manera dinámica de la librería LinqKit
            var predicate = PredicateBuilder.New<Products>(true);

            if (!filter.IsDeleted)
            {
                predicate = predicate.And(p => !p.FecBaja.HasValue);
            }

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

            var result = await _repositoryProduct.GetPagedDataAsync<ProductDto>(
                filter.Page,
                filter.PageSize,
                predicate,
                includeProperties
            );

            return result;
        }

        public async Task<OperationResponse<ProductDto>> GetByIdAsync(int id)
        {
            var response = await _repositoryProduct.GetByIdAsync<ProductDto>(id, p => p.Category, p => p.Supplier);
            return response;
        }

        public async Task<OperationResponse<ProductPostUpdate>> CreateOrUpdateAsync(ProductPostUpdate productDto)
        {
            var validateResult = await _validator.ValidateAsync(productDto);

            if (!validateResult.IsValid)
            {
                var errorMessage = string.Join(", ", validateResult.Errors.Select(error => error.ErrorMessage));
                return BadRequest<ProductPostUpdate>(errorMessage);
            }

            if (productDto.Id.HasValue)
            {
                return await UpdateAsync(productDto);
            }

            var entity = await _repositoryProduct.InsertAsync(productDto);
            var commitResult = await _unitOfWork.CommitAsync();

            if (commitResult.Data)
            {
                return Ok(_mapper.Map<ProductPostUpdate>(entity));
            }
            else
            {
                return InternalServerError<ProductPostUpdate>(commitResult.Exception);
            }
        }

        public async Task<OperationResponse<ProductPostUpdate>> UpdateAsync(ProductPostUpdate productDto)
        {
            var result = await _repositoryProduct.UpdateAsync(productDto);
            var commitResult = await _unitOfWork.CommitAsync();
            if (commitResult.Data)
            {
                return result;
            }
            else
            {
                return InternalServerError<ProductPostUpdate>(commitResult.Exception);
            }
        }

        public async Task<OperationResponse<bool>> DeleteAsync(int id)
        {
            var result = await _repositoryProduct.DeleteAsync(id);
            var commitResult = await _unitOfWork.CommitAsync();
            if (commitResult.Data)
            {
                return result;
            }
            else
            {
                return InternalServerError<bool>(commitResult.Exception);
            }
        }
    }
}