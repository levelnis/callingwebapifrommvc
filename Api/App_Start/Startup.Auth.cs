namespace Levelnis.Learning.CallingWebApiFromMvc.Api
{
    using System.Web.Http;
    using Identity;
    using Owin;

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
        }
    }
}