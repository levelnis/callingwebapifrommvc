using System.Web.Http;

namespace Levelnis.Learning.CallingWebApiFromMvc.Api.Controllers
{
    using System;
    using Models;

    [Authorize]
    public class ProductController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var product = CreateProduct(id);
            return Ok(product);
        }

        private static ProductApiModel CreateProduct(int productId)
        {
            var product = new ProductApiModel
            {
                ProductId = productId,
                Name = "Product " + productId,
                Description = "Description " + productId,
                CreatedOn = DateTime.Now
            };

            return product;
        }
    }
}
