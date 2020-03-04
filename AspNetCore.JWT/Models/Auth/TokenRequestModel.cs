using System.ComponentModel.DataAnnotations;

namespace AspNetCore.JWT.Models.Auth
{
    public class TokenRequestModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
