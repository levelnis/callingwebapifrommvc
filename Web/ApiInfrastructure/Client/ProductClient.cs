namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure.Client
{
    using System.Threading.Tasks;
    using ApiHelper;
    using ApiHelper.Client;
    using ApiModels;
    using Responses;

    public class ProductClient : ClientBase, IProductClient
    {
        private const string ProductUri = "api/product";
        private const string IdKey = "id";

        public ProductClient(IApiClient apiClient) : base(apiClient)
        {
        }

        public async Task<ProductResponse> GetProduct(int productId)
        {
            var idPair = IdKey.AsPair(productId.ToString());
            return await GetJsonDecodedContent<ProductResponse, ProductApiModel>(ProductUri, idPair);
        }
    }
}