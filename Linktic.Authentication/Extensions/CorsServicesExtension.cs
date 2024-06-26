namespace Linktic.Authentication.Extensions
{
	public static class CorsServicesExtension
	{
		public static void ConfigureCors(this IServiceCollection servicios)
		{
			servicios.AddCors(options =>
			{
				options.AddPolicy("MyOrigin",
					builder => builder.SetIsOriginAllowed(_ => true)
					 .WithMethods("GET", "POST")
					 .AllowAnyHeader()
					 .AllowAnyMethod()
					 .AllowCredentials());
			});
		}
	}
}
