using System;
using BookIt.Core.Application.Contracts.Persistence.Authentication;
using BookIt.Core.Application.Contracts.Persistence.BaseApp;
using BookIt.Core.Application.Contracts.UoW;
using BookIt.Core.Persistence.ApplicationContext;
using BookIt.Core.Persistence.Config;
using BookIt.Core.Persistence.Repository.Authentication;
using BookIt.Core.Persistence.Repository.BaseApp;
using BookIt.Core.Persistence.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BookIt.Core.Persistence
{
	public static class PersistenceConfiguration
	{
		public static IServiceCollection AddPersistenceService(this IServiceCollection service, IConfiguration configuration)
		{

			// Dependency Injection
			service.AddScoped<BaseDbContext>(); // Possibly missing line

            DbConfig? dbConfigSection = configuration.GetSection(nameof(DbConfig)).Get<DbConfig>();
            var connectionString = dbConfigSection?.ConnectionString;
            var serverVersion = new MySqlServerVersion(ServerVersion.AutoDetect(connectionString));

            service.AddDbContext<BaseDbContext>(
                dbContextOptions => dbContextOptions
                    .UseMySql(connectionString, serverVersion)
            );

            service.AddScoped(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));
			service.AddScoped<IUnitOfWork, UnitOfWork>();
			service.AddScoped<IUserRepository, UserRepository>();


            
            
            return service;
		}
	}
}

