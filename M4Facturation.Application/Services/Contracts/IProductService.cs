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
    }
}