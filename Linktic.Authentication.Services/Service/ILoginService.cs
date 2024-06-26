using Linktic.Authentication.Model.DTO;

namespace Linktic.Authentication.Services.Service
{
	public interface ILoginService
	{
		Task<ResponseDTO<string>> LoginAsync(string userName, string password);
	}
}
