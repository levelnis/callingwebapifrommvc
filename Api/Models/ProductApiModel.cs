namespace Levelnis.Learning.CallingWebApiFromMvc.Api.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProductApiModel
    {
        public int ProductId { get; set; } 

        [Required]
        public string Name { get; set; } 

        [Required]
        public string Description { get; set; } 

        public DateTime CreatedOn { get; set; } 
    }
}