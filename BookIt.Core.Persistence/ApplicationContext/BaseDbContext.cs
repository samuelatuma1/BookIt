using System;
using BookIt.Core.Domain.Authentication.Entity;
using BookIt.Core.Persistence.EntityTypeConfigurations.Authentication;
using Microsoft.EntityFrameworkCore;

namespace BookIt.Core.Persistence.ApplicationContext
{
	public class BaseDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserTypeConfiguration).Assembly);
        }
    }
}

