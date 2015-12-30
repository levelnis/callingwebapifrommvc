namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure.ApiModels
{
    using ApiHelper.Model;

    public class RegisterApiModel : ApiModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}