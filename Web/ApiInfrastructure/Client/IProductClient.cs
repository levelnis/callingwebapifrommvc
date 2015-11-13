namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure.Client
{
    using System.Threading.Tasks;
    using Responses;

    public interface IProductClient
    {
        Task<ProductResponse> GetProduct(int productId);
    }
}