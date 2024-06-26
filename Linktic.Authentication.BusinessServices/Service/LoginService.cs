using Linktic.Authentication.Model.DTO;
using Linktic.Authentication.Services.Invoker;
using Linktic.Authentication.Services.Service;

namespace Linktic.Authentication.BusinessServices.Service
{
	public class LoginService : ILoginService
	{
		private readonly IGenerateTokenInvoker generateTokenInvoker;

		public LoginService(IGenerateTokenInvoker generateTokenInvoker)
		{
			this.generateTokenInvoker = generateTokenInvoker;
		}

		public async Task<ResponseDTO<string>> LoginAsync(string userName, string password)
		{
			return await this.generateTokenInvoker.Execute(userName, password);
		}
	}
}
