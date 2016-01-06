using System.Web.Mvc;

namespace Levelnis.Learning.CallingWebApiFromMvc.Web.Controllers
{
    using System.Threading.Tasks;
    using ApiHelper.Client;
    using ApiInfrastructure;
    using ApiInfrastructure.Client;
    using Models;

    [Authorize]
    public class ProductController : BaseController
    {
        private readonly IProductClient productClient;

        /// <summary>
        /// Default parameterless constructor. 
        /// Delete this if you are using a DI container.
        /// </summary>
        public ProductController()
        {
            var contextWrapper = new TokenContainer();
            var apiClient = new ApiClient(HttpClientInstance.Instance, contextWrapper);
            productClient = new ProductClient(apiClient);
        }

        /// <summary>
        /// Default constructor with dependency.
        /// Delete this if you aren't planning on using a DI container.
        /// </summary>
        /// <param name="productClient">The product client.</param>
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