using System.ComponentModel.DataAnnotations;

namespace Loyalty.Models
{
    public class Role
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
