using System;
using BookIt.Core.Domain.Authentication.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookIt.Core.Persistence.EntityTypeConfigurations.Authentication
{
	public class UserTypeConfiguration : IEntityTypeConfiguration<User>
	{
		public UserTypeConfiguration()
		{
		}

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(user => user.Email).IsRequired();
            builder
                .HasKey(user => user.Id);
            builder
                .Property(user => user.Username).IsRequired();
        }
    }
}

