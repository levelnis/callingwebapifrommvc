using System.Web.Http;

namespace Levelnis.Learning.CallingWebApiFromMvc.Api.Controllers
{
    using Models;

    public class ProductsController : ApiController
    {
        public IHttpActionResult Post(ProductApiModel model)
        {
            // should do some mapping and save a product in a data store somewhere, but we don't care about that for our little demo
            return Ok(7);
        }
    }
}
