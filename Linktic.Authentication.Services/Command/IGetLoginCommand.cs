using Linktic.Authentication.Model.DTO;

namespace Linktic.Authentication.Services.Command
{
	public interface IGetLoginCommand
	{
		Task<ResponseDTO<LoginDTO>> Execute(string userName, string password);
	}
}
