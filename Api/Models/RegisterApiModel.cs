namespace Levelnis.Learning.CallingWebApiFromMvc.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterApiModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }
    }
}