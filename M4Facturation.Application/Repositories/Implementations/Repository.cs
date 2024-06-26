namespace M4Facturation.Application.Repositories.Implementations
{
    public abstract class Repository<TEntity>(
        PointSaleContext _context,
        ICacheService cacheService,
        IMapper mapper)
        : BaseService(cacheService, mapper), IRepository<TEntity> where TEntity : class

    {
        public async Task<OperationResponse<List<TDto>>> FindByConditionAsyncLongCache<TDto>(
            Expression<Func<TEntity, bool>> condition, string cacheKey)
        {
            var cacheResponse = _cacheService.GetCache(cacheKey);
            if (cacheResponse.Data is List<TDto> cachedData)
            {
                return Ok(cachedData);
            }

            var entities = await _context.Set<TEntity>().Where(condition).ToListAsync();

            var dtos = _mapper.Map<List<TDto>>(entities);

            _cacheService.SetLongCache(cacheKey, dtos);

            return Ok(dtos);
        }

        public async Task<OperationResponse<List<TDto>>> GetPagedDataAsync<TDto>(
            int page, int pageSize,
            Expression<Func<TEntity, bool>> condition,
            params Expression<Func<TEntity, object>>[]? includeProperties)
        {
            var query = _context.Set<TEntity>().Where(condition);

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var total = await query.CountAsync();

            if (total == 0)
            {
                return NotFound<List<TDto>>();
            }

            var entitiesFilter = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var dtos = _mapper.Map<List<TDto>>(entitiesFilter);

            return Ok(dtos, total);
        }

        public async Task<TEntity> InsertAsync<TDto>(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            
            if (entity is IEntityAuditable auditableEntity)
            {
                auditableEntity.UserIng = _cacheService.GetUserCache().Data;
                auditableEntity.FecIng = DateTime.Now;
            }
            
            await _context.Set<TEntity>().AddAsync(entity);
            
            return entity;
        }

        public async Task<OperationResponse<TDto>> UpdateAsync<TDto>(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            if (entity is IEntityAuditable auditableEntity)
            {
                auditableEntity.UserMod = _cacheService.GetUserCache().Data;
                auditableEntity.FecMod = DateTime.Now;
            }

            _context.Set<TEntity>().Update(entity);

            return Ok(_mapper.Map<TDto>(entity));
        }

        public async Task<OperationResponse<bool>> DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity is IEntityAuditable auditableEntity)
            {
                auditableEntity.UserBaja = _cacheService.GetUserCache().Data;
                auditableEntity.FecBaja = DateTime.Now;
            }

            _context.Set<TEntity>().Update(entity);

            return Ok(true);
        }

        public async Task<OperationResponse<List<TDto>>> GetAll<TDto>(
            Expression<Func<TEntity, bool>>? condition = null,
            params Expression<Func<TEntity, object>>[]? includeProperties)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (condition != null)
            {
                query = query.Where(condition);
            }

            query = GetPropertiesQuery<TDto>(includeProperties, query);

            var entities = await query.ToListAsync();

            var dtos = _mapper.Map<List<TDto>>(entities);

            return Ok(dtos);
        }

        private static IQueryable<TEntity> GetPropertiesQuery<TDto>(
            Expression<Func<TEntity, object>>[]? includeProperties, IQueryable<TEntity> query)
        {
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }

            return query;
        }

        public async Task<OperationResponse<TDto>> GetByIdAsync<TDto>(int id,
            params Expression<Func<TEntity, object>>[]? includeProperties)
        {
            var query = _context.Set<TEntity>().Where(e => EF.Property<DateTime>(e, "FecBaja") == null);

            query = GetPropertiesQuery<TDto>(includeProperties, query);

            var entity = await query.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

            if (entity == null)
            {
                return NotFound<TDto>();
            }

            return Ok(_mapper.Map<TDto>(entity));
        }
    }
}