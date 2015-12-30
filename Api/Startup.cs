using Microsoft.Owin;

[assembly: OwinStartup(typeof(Levelnis.Learning.CallingWebApiFromMvc.Api.Startup))]

namespace Levelnis.Learning.CallingWebApiFromMvc.Api
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}