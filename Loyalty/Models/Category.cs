using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Loyalty.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Category Name")]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
