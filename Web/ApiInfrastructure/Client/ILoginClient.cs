namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure.Client
{
    using System.Threading.Tasks;
    using ApiModels;
    using Models;
    using Responses;

    public interface ILoginClient
    {
        Task<RegisterResponse> Register(RegisterViewModel viewModel);
    }
}