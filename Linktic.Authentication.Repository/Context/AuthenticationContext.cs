using Linktic.Authentication.Repository.Configuration;
using Linktic.Authentication.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace Linktic.Authentication.Repository.Context
{
	public class AuthenticationContext : DbContext
	{
		public DbSet<Rol> Rol { get; set; }
		public DbSet<Login> Login { get; set; }

		public AuthenticationContext(DbContextOptions options) : base(options)
		{
		}

		public AuthenticationContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new RolEntityConfiguration());
			modelBuilder.ApplyConfiguration(new LoginEntityConfiguration());
		}
	}
}
