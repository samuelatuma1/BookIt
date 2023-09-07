using System;
using BookIt.Core.Application.Contracts.UoW;
using BookIt.Core.Persistence.ApplicationContext;

namespace BookIt.Core.Persistence.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
        private readonly BaseDbContext _dbContext;

        public UnitOfWork(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync(CancellationToken token)
        {
            await _dbContext.SaveChangesAsync(token);
        }
    }
}

