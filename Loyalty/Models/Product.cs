using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loyalty.Models
{
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Display(Name = "Product Quantity")]
        public int quan { get; set; }

        [Display(Name = "Product Description")]
        public string des { get; set; }

        public int cat_id { get; set; }

        [ForeignKey("cat_id")]
        public virtual Category Category { get; set; }
    }
}
