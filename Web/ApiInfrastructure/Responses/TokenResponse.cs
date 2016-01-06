namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure.Responses
{
    using ApiHelper.Response;

    public class TokenResponse : ApiResponse
    {
        public string ApiToken { get; set; }
    }
}