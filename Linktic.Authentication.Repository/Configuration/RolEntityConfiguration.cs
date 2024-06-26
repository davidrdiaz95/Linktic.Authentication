using Linktic.Authentication.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Linktic.Authentication.Repository.Configuration
{
	public class RolEntityConfiguration : IEntityTypeConfiguration<Rol>
	{
		public void Configure(EntityTypeBuilder<Rol> builder)
		{
			builder.ToTable("Rol");
			builder.Property(x => x.Id).HasColumnName("id");
			builder.Property(x => x.Name).HasColumnName("name");
			builder.HasKey(x => x.Id);
		}
	}
}
