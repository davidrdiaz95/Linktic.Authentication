using Linktic.Authentication.Middlewares;

namespace Linktic.Authentication.Extensions
{
	public static class ExtencionServicioErrores
	{
		public static void UseErrorHanldinMiddleware(this IApplicationBuilder app)
		{
			app.UseMiddleware<ErrorHandlerMiddleware>(Array.Empty<object>());
		}
	}
}
