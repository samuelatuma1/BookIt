using System;
using BookIt.Core.Application.Contracts.Persistence.Authentication;
using BookIt.Core.Domain.Authentication.Entity;
using BookIt.Core.Domain.Authentication.Model;
using BookIt.Core.Persistence.ApplicationContext;
using BookIt.Core.Persistence.Repository.BaseApp;

namespace BookIt.Core.Persistence.Repository.Authentication
{
	public class UserRepository : BaseRepository<User, UserModel, Guid>, IUserRepository
	{
		public UserRepository(BaseDbContext dbContext) : base(dbContext)
		{
		}

        public async Task<bool> CheckUniqueEmailAsync(string email)
        {

            var user = await FirstOrDefaultAsync(user => user.Email == email);
            return user != null;
        }
    }
}

