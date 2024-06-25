namespace M4Facturation.Application.UnitOfWork.Implementations
{
    public sealed class UnitOfWork(PointSaleContext context, IServiceProvider serviceProvider) : BaseService, IUnitOfWork
    {
        private bool _disposed;

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return serviceProvider.GetRequiredService<IRepository<TEntity>>();
        }

        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            return serviceProvider.GetRequiredService<TRepository>();
        }

        public async Task<OperationResponse<bool>> CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return InternalServerError<bool>(ex.Message);
            }
        }

        public async Task RollbackAsync()
        {
            await context.Database.RollbackTransactionAsync();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}