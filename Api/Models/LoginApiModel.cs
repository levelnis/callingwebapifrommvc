using System.ComponentModel.DataAnnotations;

namespace Levelnis.Learning.CallingWebApiFromMvc.Api.Models
{
    public class LoginApiModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}