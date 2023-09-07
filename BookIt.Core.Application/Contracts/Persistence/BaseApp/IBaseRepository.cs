using System;
using BookIt.Core.Domain.BaseApp.Entity;
using BookIt.Core.Domain.BaseApp.Model;

namespace BookIt.Core.Application.Contracts.Persistence.BaseApp
{
	public interface IBaseRepository<TEntity, TModel, TId>
		where TEntity : BaseEntity<TId>
		where TModel : BaseModel<TId>
	{
        Task<TEntity> AddAsync(TEntity entity);
		Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

		// Retrieve
		Task<TEntity?> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<IEnumerable<TModel>> GetModelAsync();
        Task<IEnumerable<TEntity>> GetAsync(Func<TEntity, bool> query);
        Task<TEntity?> FirstOrDefaultAsync(Func<TEntity, bool> query);

        // Update
        Task<TEntity> UpdateByIdAsync(TId id, TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
		Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities);

		// Delete
		Task<int> DeleteByIdAsync(TId id, bool soft = true);
        Task<int> DeleteAsync(TEntity entity, bool soft = true);

    }
}

