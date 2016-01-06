namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure.Client
{
    using System.Threading.Tasks;
    using Models;
    using Responses;

    public interface ILoginClient
    {
        Task<TokenResponse> Login(string email, string password);
        Task<RegisterResponse> Register(RegisterViewModel viewModel);
    }
}