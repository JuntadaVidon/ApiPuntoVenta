using M4Facturation.Application.RequestDto.Products;
using M4Facturation.Application.ResponseDto.Products;
using M4Facturation.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace M4Facturation.API.Controllers
{
    public class ProductsController(IProductService _productService) : BaseController
    {
        /// <summary>
        /// Obtiene una lista filtrada de productos según los criterios especificados.
        /// </summary>
        /// <param name="filter">Filtros a aplicar en la búsqueda de productos.</param>
        /// <returns>Una operación asincrónica que devuelve una lista de productos filtrados.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(OperationResponseSwagger<List<ProductDto>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] ProductFilterDto filter)
        {
            var result = await _productService.GetFilteredProductsAsync(filter);
            return Return(result);
        }

        /// <summary>
        /// Obtiene un producto por su identificador único.
        /// </summary>
        /// <param name="id">Identificador único del producto.</param>
        /// <returns>Una operación asincrónica que devuelve el producto encontrado.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OperationResponseSwagger<ProductDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            return Return(result);
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="productDto">Datos del producto a crear.</param>
        /// <returns>Una operación asincrónica que devuelve el producto creado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(OperationResponseSwagger<ProductPostUpdate>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] ProductPostUpdate productDto)
        {
            var result = await _productService.CreateOrUpdateAsync(productDto);
            return Return(result);
        }

        /// <summary>
        /// Elimina un producto existente.
        /// </summary>
        /// <param name="id">Identificador único del producto a eliminar.</param>
        /// <returns>Una operación asincrónica que indica si se eliminó correctamente.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OperationResponseSwagger<bool>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return Return(result);
        }
    }
}