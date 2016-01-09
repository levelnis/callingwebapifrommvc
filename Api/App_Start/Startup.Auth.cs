namespace Levelnis.Learning.CallingWebApiFromMvc.Api
{
    using System;
    using System.Web.Http;
    using Identity;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.OAuth;
    using Owin;
    using Providers;

    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            var oAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/api/token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            };
            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(oAuthOptions);
        }
    }
}