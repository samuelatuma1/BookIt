using System;
using BookIt.Core.Application.Contracts.Persistence.BaseApp;
using BookIt.Core.Application.Exceptions;
using BookIt.Core.Application.Utilities;
using BookIt.Core.Domain.BaseApp.Entity;
using BookIt.Core.Domain.BaseApp.Enum;
using BookIt.Core.Domain.BaseApp.Model;
using BookIt.Core.Persistence.ApplicationContext;
using Microsoft.EntityFrameworkCore;

namespace BookIt.Core.Persistence.Repository.BaseApp
{
	public class BaseRepository<TEntity, TModel, TId> : IBaseRepository<TEntity, TModel, TId>
        where TEntity : BaseEntity<TId>
        where TModel : BaseModel<TId>
    {
        protected readonly BaseDbContext _dbContext;
        public BaseRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            // add createdat and updatedat to entity
            entity.CreatedAt = DateTimeUtilities.GetCurrentDateTime();
            entity.UpdatedAt = DateTimeUtilities.GetCurrentDateTime();
            // set entity recordstatus to active
            entity.RecordStatus = RecordStatus.Active;

            // save to db
            await _dbContext.Set<TEntity>().AddAsync(entity);
            // return entity
            return entity;
        }

        public async virtual Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            // Loop through entities
            entities = entities.Select(entity =>
            {
                // add createdat and updatedat to entity
                entity.CreatedAt = DateTimeUtilities.GetCurrentDateTime();
                entity.UpdatedAt = DateTimeUtilities.GetCurrentDateTime();
                // set entity recordstatus to active
                entity.RecordStatus = RecordStatus.Active;

                return entity;
            });

            await _dbContext.Set<TEntity>().AddRangeAsync(entities);

            return entities;
        }

        public async Task<int> DeleteAsync(TEntity entity, bool soft = true)
        {
            return await DeleteByIdAsync(entity.Id, soft);
        }

        public async Task<int> DeleteByIdAsync(TId id, bool soft = true)
        {
            TEntity? entityExists = await GetByIdAsync(id);
            int count = 0;
            if (entityExists is not null)
            {

                if (soft)
                {
                    entityExists.RecordStatus = RecordStatus.Deleted;
                }
                else
                {
                    _dbContext.Set<TEntity>().Remove(entityExists);
                }
                count = 1;
            }
            return count;
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            await Task.CompletedTask;
            return _dbContext.Set<TEntity>().AsNoTracking(); 
        }

        public async Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> query)
        {
            await Task.CompletedTask;
            return  _dbContext.Set<TEntity>().Where(query);
        }

        public async Task<TEntity?> GetByIdAsync(TId id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public Task<IEnumerable<TModel>> GetModelAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {

            throw new NotImplementedException();
        }

        public async Task<TEntity> UpdateByIdAsync(TId id, TEntity entity)
        {
            TEntity? entityExists = await GetByIdAsync(id);

            if (entityExists is not null)
            {
                if (!entity.Id.Equals(id))
                    throw new KeyDoesNotMatchException("Entity and id does not match");

                entity.UpdatedAt = DateTimeUtilities.GetCurrentDateTime();
                _dbContext.Set<TEntity>().Update(entity);
            }
            return entity;
        }

        public async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            
            entities = entities.Select(entity =>
            {
                entity.UpdatedAt = DateTimeUtilities.GetCurrentDateTime();
                return entity;
            });
            await Task.CompletedTask;
            _dbContext.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        public async Task<TEntity?> FirstOrDefaultAsync(Func<TEntity, bool> query)
        {
            await Task.CompletedTask;
            return _dbContext.Set<TEntity>().FirstOrDefault(query);
        }
    }
}

