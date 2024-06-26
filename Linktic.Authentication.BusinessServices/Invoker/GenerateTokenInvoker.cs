using Linktic.Authentication.Model.DTO;
using Linktic.Authentication.Model.Section;
using Linktic.Authentication.Model.Util;
using Linktic.Authentication.Services.Command;
using Linktic.Authentication.Services.Invoker;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Linktic.Authentication.BusinessServices.Invoker
{
	public class GenerateTokenInvoker : IGenerateTokenInvoker
    {
        private readonly TokenConfiguration tokenConfiguration;
        private readonly IGetLoginCommand getLoginCommand;

        public GenerateTokenInvoker(IOptions<TokenConfiguration> options,
            IGetLoginCommand getLoginCommand)
        {
            tokenConfiguration = options.Value;
            this.getLoginCommand = getLoginCommand;
        }

        public async Task<ResponseDTO<string>> Execute(string userName, string password)
        {
            var user = await getLoginCommand.Execute(userName, password);
            if (!user.StatusCode.Equals(HttpStatusCode.OK))
                return ResponseStatus.ResponseWithoutData<string>("No se encontro el usuario");

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, user.Data.RolName));

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secrect));
            SigningCredentials creds = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddSeconds(tokenConfiguration.ExpirationTime),
                signingCredentials: creds);

            return token != null ?
				ResponseStatus.ResponseSucessful<string>(new JwtSecurityTokenHandler().WriteToken(token)) :
				ResponseStatus.ResponseWithoutData<string>("No se encontro el usuario");
		}
    }
}
