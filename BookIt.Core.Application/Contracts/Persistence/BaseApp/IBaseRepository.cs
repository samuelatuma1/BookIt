using System;
using BookIt.Core.Domain.BaseApp.Entity;
using BookIt.Core.Domain.BaseApp.Model;

namespace BookIt.Core.Application.Contracts.Persistence.BaseApp
{
	public interface IBaseRepository<TEntity, TModel, TId>
		where TEntity : BaseEntity<TId>
		where TModel : BaseModel<TId>
	{
		Task<TModel> AddAsync(TEntity entity);
		Task<IEnumerable<TModel>> AddRangeAsync(IEnumerable<TEntity> entities);

		// Retrieve
		Task<TModel?> GetByIdAsync(TId id);
        Task<IEnumerable<TModel>> GetAsync();
        Task<IEnumerable<TModel>> GetAsync(Func<TEntity, bool> query);

		// Update
		Task<TEntity> UpdateByIdAsync(TId id, TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
		Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities);

		// Delete
		Task<int> DeleteByIdAsync(TId id, bool soft = true);
        Task<int> DeleteAsync(TEntity entity, bool soft = true);
    }
}

