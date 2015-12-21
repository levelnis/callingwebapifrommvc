using System.Web.Mvc;

namespace Levelnis.Learning.CallingWebApiFromMvc.Web.Controllers
{
    using System.Threading.Tasks;
    using ApiHelper.Client;
    using ApiInfrastructure;
    using ApiInfrastructure.Client;
    using Models;

    public class ProductController : BaseController
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

        public ActionResult CreateProduct()
        {
            var model = new ProductViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateProduct(ProductViewModel model)
        {
            var response = await productClient.CreateProduct(model);
            if (response.StatusIsSuccessful)
            {
                var productId = response.Data;
                return RedirectToAction("GetProduct", new { id = productId });
            }

            AddResponseErrorsToModelState(response);
            return View(model);
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