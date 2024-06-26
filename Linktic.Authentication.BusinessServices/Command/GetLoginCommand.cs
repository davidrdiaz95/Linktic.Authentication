using Linktic.Authentication.Model.DTO;
using Linktic.Authentication.Model.Util;
using Linktic.Authentication.Repository.Entity;
using Linktic.Authentication.Repository.Repository.Interface;
using Linktic.Authentication.Services.Command;
using Linktic.Authentication.Services.Mapper;

namespace Linktic.Authentication.BusinessServices.Command
{
	public class GetLoginCommand : IGetLoginCommand
	{
		private readonly IRepository<Login> repository;
		private readonly IMapper<Login, LoginDTO> mapper;

		public GetLoginCommand(IRepository<Login> repository,
			IMapper<Login, LoginDTO> mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<ResponseDTO<LoginDTO>> Execute(string userName, string password)
		{
			var login = this.repository.FindByInclude(x => x.UserName.Equals(userName) && x.Password.Equals(password), i => i.Rol);
			return GenericValidations.OwnData(login) ?
				ResponseStatus.ResponseSucessful<LoginDTO>(this.mapper.MapFrom(login.First())) :
				ResponseStatus.ResponseWithoutData<LoginDTO>("No se encontro el usuario");
		}
	}
}
