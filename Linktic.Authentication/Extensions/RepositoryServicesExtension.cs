using Linktic.Authentication.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace Linktic.Authentication.Extensions
{
	public static class RepositoryServicesExtension
	{
		public static void ConfigureDataBaseConnection(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<AuthenticationContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});
		}
	}
}
