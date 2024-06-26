namespace M4Facturation.Application.Contracts
{
    /// <summary>
    /// Interfaz para el servicio de productos.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Obtiene una lista de productos filtrados según los criterios especificados.
        /// </summary>
        /// <param name="filter">Objeto que contiene los criterios de filtrado.</param>
        /// <returns>Una lista de DTOs de productos que cumplen con los criterios de filtrado.</returns>
        Task<OperationResponse<List<ProductDto>>> GetFilteredProductsAsync(ProductFilterDto filter);

        /// <summary>
        /// Obtiene un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto a obtener.</param>
        /// <returns>DTO del producto.</returns>
        Task<OperationResponse<ProductDto>> GetByIdAsync(int id);

        /// <summary>
        /// Crea un nuevo producto o lo actualizar si ya existe.
        /// </summary>
        /// <param name="productDto">DTO del producto a crear o actualizar.</param>
        /// <returns>DTO del producto creado.</returns>
        Task<OperationResponse<ProductPostUpdate>> CreateOrUpdateAsync(ProductPostUpdate productDto);
        

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">ID del producto a eliminar.</param>
        /// <returns>Indicador de éxito de la operación.</returns>
        Task<OperationResponse<bool>> DeleteAsync(int id);
    }
}