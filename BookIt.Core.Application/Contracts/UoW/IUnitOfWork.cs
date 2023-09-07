using System;
namespace BookIt.Core.Application.Contracts.UoW
{
	public interface IUnitOfWork
	{
        Task SaveChangesAsync();
        Task SaveChangesAsync(CancellationToken token);
    }
}

