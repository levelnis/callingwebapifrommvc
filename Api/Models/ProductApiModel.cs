namespace Levelnis.Learning.CallingWebApiFromMvc.Api.Models
{
    using System;

    public class ProductApiModel
    {
        public int ProductId { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; } 
        public DateTime CreatedOn { get; set; } 
    }
}