namespace Levelnis.Learning.CallingWebApiFromMvc.Web.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using ApiHelper;
    using ApiHelper.Client;
    using ApiInfrastructure.Client;
    using Models;

    public class HomeController : Controller
    {
        private readonly IProductClient productClient;

        public HomeController()
        {
            var apiClient = new ApiClient();
            productClient = new ProductClient(apiClient);
        }

        public HomeController(IProductClient productClient)
        {
            this.productClient = productClient;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Product(int id)
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