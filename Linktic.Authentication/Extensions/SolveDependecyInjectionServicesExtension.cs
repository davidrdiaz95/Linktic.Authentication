using Linktic.Authentication.BusinessServices.Mapper;
using Linktic.Authentication.Model.DTO;
using Linktic.Authentication.Repository.Entity;
using Linktic.Authentication.Repository.Repository.Interface;
using Linktic.Authentication.Repository.Repository.Service;
using Linktic.Authentication.Services.Mapper;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace Linktic.Authentication.Extensions
{
	public static class SolveDependecyInjectionServicesExtension
	{
		public static void ConfigureDependencyInjection(this IServiceCollection services)
		{
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			services.AddScoped(typeof(IMapper<Login, LoginDTO>), typeof(LoginMapper));

			Assembly assemblyServicesInterface = AppDomain.CurrentDomain.Load("Linktic.Authentication.Services");
			Assembly assemblyServicesImplementation = AppDomain.CurrentDomain.Load("Linktic.Authentication.BusinessServices");
			Assembly assemblyDataInterface = AppDomain.CurrentDomain.Load("Linktic.Authentication.Repository");
			Assembly assemblyDataImplementation = AppDomain.CurrentDomain.Load("Linktic.Authentication.Repository");

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Command"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Invoker"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Service"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
				.Where(c => c.Name.EndsWith("Mapper"))
				.AsPublicImplementedInterfaces();

			services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDataInterface, assemblyDataImplementation })
				.Where(c => c.Name.Contains("QueryObject"))
				.AsPublicImplementedInterfaces();

		}
	}
}
