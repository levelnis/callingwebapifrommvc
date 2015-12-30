namespace Levelnis.Learning.CallingWebApiFromMvc.Api.Controllers
{
    using System.Web.Http;
    using Models;

    public class RegisterController : ApiController
    {
        public IHttpActionResult Post(RegisterApiModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
