namespace Levelnis.Learning.CallingWebApiFromMvc.Web.ApiInfrastructure.ApiModels
{
    using System;
    using ApiHelper.Model;

    public class ProductApiModel : ApiModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}