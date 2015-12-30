using System.Web.Mvc;
using Levelnis.Learning.CallingWebApiFromMvc.Web.Models;

namespace Levelnis.Learning.CallingWebApiFromMvc.Web.Controllers
{
    using System.Threading.Tasks;
    using ApiHelper.Client;
    using ApiInfrastructure;
    using ApiInfrastructure.Client;

    public class AccountController : BaseController
    {
        private readonly ILoginClient loginClient;

        public AccountController()
        {
            var apiClient = new ApiClient(HttpClientInstance.Instance);
            loginClient = new LoginClient(apiClient);
        }

        public AccountController(ILoginClient loginClient)
        {
            this.loginClient = loginClient;
        }

        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var response = await loginClient.Register(model);
            if (response.StatusIsSuccessful)
            {
                
            }

            AddResponseErrorsToModelState(response);
            return View(model);
        }
    }
}