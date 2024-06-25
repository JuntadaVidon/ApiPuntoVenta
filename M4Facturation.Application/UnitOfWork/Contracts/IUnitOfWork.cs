namespace M4Facturation.Application.UnitOfWork.Contracts
{
    /// <summary>
    /// Interfaz para la Unidad de Trabajo (UnitOfWork).
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Confirma los cambios realizados en la unidad de trabajo de manera asincrónica.
        /// </summary>
        /// <returns>Respuesta de la operación que indica si la confirmación fue exitosa.</returns>
        Task<OperationResponse<bool>> CommitAsync();

        /// <summary>
        /// Revierte los cambios realizados en la unidad de trabajo de manera asincrónica.
        /// </summary>
        /// <returns>Tarea representando la operación de reversión.</returns>
        Task RollbackAsync();

        /// <summary>
        /// Obtiene el repositorio genérico para el tipo de entidad especificado.
        /// </summary>
        /// <typeparam name="TEntity">Tipo de la entidad.</typeparam>
        /// <returns>Repositorio para el tipo de entidad especificado.</returns>
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;

        /// <summary>
        /// Obtiene el repositorio específico del tipo especificado.
        /// </summary>
        /// <typeparam name="TRepository">Tipo del repositorio.</typeparam>
        /// <returns>Instancia del repositorio del tipo especificado.</returns>
        TRepository GetRepository<TRepository>() where TRepository : class;
    }
}