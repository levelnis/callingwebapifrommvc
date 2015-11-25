namespace Levelnis.Learning.CallingWebApiFromMvc.Web.Controllers
{
    using System.Web.Mvc;
    using ApiHelper.Response;

    public abstract class BaseController : Controller
    {
        protected void AddResponseErrorsToModelState(ApiResponse response)
        {
            var errors = response.ErrorState.ModelState;
            if (errors == null)
            {
                return;
            }

            foreach (var error in errors)
            {
                ModelState.AddModelError(error.Key, error.Value[0]);
            }
        }
    }
}