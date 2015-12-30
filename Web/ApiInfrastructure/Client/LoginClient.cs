namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure.Client
{
    using System.Threading.Tasks;
    using ApiHelper.Client;
    using ApiModels;
    using Models;
    using Responses;

    public class LoginClient : ClientBase, ILoginClient
    {
        private const string RegisterUri = "api/register";

        public LoginClient(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<RegisterResponse> Register(RegisterViewModel viewModel)
        {
            var apiModel = new RegisterApiModel
            {
                ConfirmPassword = viewModel.ConfirmPassword,
                Email = viewModel.Email,
                Password = viewModel.Password
            };
            var response = await ApiClient.PostJsonEncodedContent(RegisterUri, apiModel);
            var registerResponse = await CreateJsonResponse<RegisterResponse>(response);
            return registerResponse;
        }
    }
}