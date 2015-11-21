using System.Web.Mvc;

namespace Levelnis.Learning.CallingWebApiFromMvc.Web.Controllers
{
    using System.Threading.Tasks;
    using ApiHelper.Client;
    using ApiInfrastructure;
    using ApiInfrastructure.Client;
    using Models;

    public class ProductController : Controller
    {
        private readonly IProductClient productClient;

        public ProductController()
        {
            var apiClient = new ApiClient(HttpClientInstance.Instance);
            productClient = new ProductClient(apiClient);
        }

        public ProductController(IProductClient productClient)
        {
            this.productClient = productClient;
        }

        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await productClient.GetProduct(id);
            var model = new ProductViewModel
            {
                ProductId = product.Data.ProductId,
                Name = product.Data.Name,
                Description = product.Data.Description,
                CreatedOn = product.Data.CreatedOn.ToLongDateString() + " " + product.Data.CreatedOn.ToLongTimeString()
            };
            return View(model);
        }
    }
}