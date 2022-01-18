using System.ComponentModel.DataAnnotations;

namespace Loyalty.Models
{
    public class Auther
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
