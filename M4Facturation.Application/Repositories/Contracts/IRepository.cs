namespace M4Facturation.Application.Repositories.Contracts
{
    /// <summary>
    /// Interfaz para el repositorio genérico.
    /// </summary>
    /// <typeparam name="TEntity">Tipo de la entidad.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Encuentra entidades por condición con un cache largo.
        /// </summary>
        /// <typeparam name="TDto">Tipo del DTO.</typeparam>
        /// <param name="condition">Condición para filtrar las entidades.</param>
        /// <param name="cacheKey">Clave para el cache.</param>
        /// <returns>Lista de DTOs que cumplen con la condición.</returns>
        Task<OperationResponse<List<TDto>>> FindByConditionAsyncLongCache<TDto>(
            Expression<Func<TEntity, bool>> condition, string cacheKey);

        /// <summary>
        /// Obtiene datos paginados.
        /// </summary>
        /// <typeparam name="TDto">Tipo del DTO.</typeparam>
        /// <param name="page">Número de página.</param>
        /// <param name="pageSize">Tamaño de la página.</param>
        /// <param name="condition">Condición para filtrar las entidades.</param>
        /// <param name="includeProperties">Propiedades a incluir en la consulta.</param>
        /// <returns>Lista de DTOs que cumplen con la condición.</returns>
        Task<OperationResponse<List<TDto>>> GetPagedDataAsync<TDto>(
            int page, int pageSize,
            Expression<Func<TEntity, bool>> condition,
            params Expression<Func<TEntity, object>>[]? includeProperties);

        /// <summary>
        /// Inserta una entidad.
        /// </summary>
        /// <typeparam name="TDto">Tipo del DTO.</typeparam>
        /// <param name="dto">DTO a insertar.</param>
        /// <returns>DTO insertado.</returns>
        Task<TEntity> InsertAsync<TDto>(TDto dto);

        /// <summary>
        /// Actualiza una entidad.
        /// </summary>
        /// <typeparam name="TDto">Tipo del DTO.</typeparam>
        /// <param name="dto">DTO a actualizar.</param>
        /// <returns>DTO actualizado.</returns>
        Task<OperationResponse<TDto>> UpdateAsync<TDto>(TDto dto);

        /// <summary>
        /// Elimina una entidad.
        /// </summary>
        /// <param name="id">ID de la entidad a eliminar.</param>
        /// <returns>Verdadero si la entidad fue eliminada exitosamente, falso en caso contrario.</returns>
        Task<OperationResponse<bool>> DeleteAsync(int id);

        /// <summary>
        /// Obtiene todas las entidades que cumplen con la condición.
        /// </summary>
        /// <typeparam name="TDto">Tipo del DTO.</typeparam>
        /// <param name="condition">Condición para filtrar las entidades. Si es null, se obtienen todas las entidades.</param>
        /// <param name="includeProperties">Propiedades a incluir en la consulta.</param>
        /// <returns>Lista de DTOs que cumplen con la condición.</returns>
        Task<OperationResponse<List<TDto>>> GetAll<TDto>(Expression<Func<TEntity, bool>>? condition = default,
            params Expression<Func<TEntity, object>>[]? includeProperties);

        /// <summary>
        /// Obtiene una entidad por su ID.
        /// </summary>
        /// <typeparam name="TDto">Tipo del DTO.</typeparam>
        /// <param name="id">ID de la entidad a obtener.</param>
        /// <param name="includeProperties">Propiedas a incluir en la consulta</param>
        /// <returns>DTO de la entidad obtenida.</returns>
        Task<OperationResponse<TDto>> GetByIdAsync<TDto>(int id,  params Expression<Func<TEntity, object>>[]? includeProperties);
    }
}
