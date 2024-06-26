using Linktic.Authentication.Model.DTO;
using Linktic.Authentication.Repository.Entity;
using Linktic.Authentication.Services.Mapper;

namespace Linktic.Authentication.BusinessServices.Mapper
{
	public class LoginMapper : IMapper<Login, LoginDTO>
	{
		public LoginDTO MapFrom(Login model)
		{
			var login = new LoginDTO();
			login.IdRol = model.FkIdRol;
			login.RolName = model.Rol.Name;
			login.Id = model.Id;
			return login;
		}

		public Login MapTo(LoginDTO model)
		{
			throw new NotImplementedException();
		}
	}
}
