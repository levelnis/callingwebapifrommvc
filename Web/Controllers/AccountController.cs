using System.Web.Mvc;
using Levelnis.Learning.CallingWebApiFromMvc.Web.Models;

namespace Levelnis.Learning.CallingWebApiFromMvc.Web.Controllers
{
    using System.Threading.Tasks;
    using ApiHelper;
    using ApiHelper.Client;
    using ApiInfrastructure;
    using ApiInfrastructure.Client;

    public class AccountController : BaseController
    {
        private readonly ILoginClient loginClient;
        private readonly ITokenContainer tokenContainer;

        /// <summary>
        /// Default parameterless constructor. 
        /// Delete this if you are using a DI container.
        /// </summary>
        public AccountController()
        {
            tokenContainer = new TokenContainer();
            var apiClient = new ApiClient(HttpClientInstance.Instance, tokenContainer);
            loginClient = new LoginClient(apiClient);
        }

        /// <summary>
        /// Default constructor with dependency.
        /// Delete this if you aren't planning on using a DI container.
        /// </summary>
        /// <param name="loginClient">The login client.</param>
        /// <param name="tokenContainer">The token container.</param>
        public AccountController(ILoginClient loginClient, ITokenContainer tokenContainer)
        {
            this.loginClient = loginClient;
            this.tokenContainer = tokenContainer;
        }

        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var loginSuccess = await PerformLoginActions(model.Email, model.Password);
            if (loginSuccess)
            {
                return RedirectToAction("CreateProduct", "Product");
            }

            ModelState.Clear();
            ModelState.AddModelError("", "The username or password is incorrect");
            return View(model);
        }

        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var response = await loginClient.Register(model);
            if (response.StatusIsSuccessful)
            {
                return RedirectToAction("Index", "Home");
            }

            AddResponseErrorsToModelState(response);
            return View(model);
        }

        private async Task<bool> PerformLoginActions(string email, string password)
        {
            var response = await loginClient.Login(email, password);
            if (response.StatusIsSuccessful)
            {
                tokenContainer.ApiToken = response.Data;
            }

            return response.StatusIsSuccessful;
        }
    }
}