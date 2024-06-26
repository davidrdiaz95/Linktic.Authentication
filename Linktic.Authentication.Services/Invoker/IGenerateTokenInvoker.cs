using Linktic.Authentication.Model.DTO;

namespace Linktic.Authentication.Services.Invoker
{
    public interface IGenerateTokenInvoker
    {
        Task<ResponseDTO<string>> Execute(string userName, string password);
    }
}
