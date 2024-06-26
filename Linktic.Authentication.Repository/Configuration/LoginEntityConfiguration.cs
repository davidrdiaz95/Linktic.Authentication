using Linktic.Authentication.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Linktic.Authentication.Repository.Configuration
{
	public class LoginEntityConfiguration : IEntityTypeConfiguration<Login>
	{
		public void Configure(EntityTypeBuilder<Login> builder)
		{
			builder.ToTable("Login");
			builder.Property(x => x.Id).HasColumnName("id");
			builder.Property(x => x.UserName).HasColumnName("user_name");
			builder.Property(x => x.Password).HasColumnName("password");
			builder.Property(x => x.Id).HasColumnName("id");
			builder.Property(x => x.FkIdRol).HasColumnName("fk_id_rol");
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Rol).WithMany(x=> x.Login).HasForeignKey(x=> x.FkIdRol);
		}
	}
}
