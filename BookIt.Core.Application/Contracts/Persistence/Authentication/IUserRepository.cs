using System;
using BookIt.Core.Application.Contracts.Persistence.BaseApp;
using BookIt.Core.Domain.Authentication.Entity;
using BookIt.Core.Domain.Authentication.Model;

namespace BookIt.Core.Application.Contracts.Persistence.Authentication
{
	public interface IUserRepository : IBaseRepository<User, UserModel, Guid>
	{
		Task<bool> CheckUniqueEmailAsync(string email);
	}
}

