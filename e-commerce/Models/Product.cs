using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    public class Product
    {
        public Product()
        {
            New = true;
            Sale = false;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }
        public string? ProductImageLink { get; set; }

        [Required(ErrorMessage = "Season is required.")]
        public int SeasonID { get; set; }
        public Season? Season { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public int GenderID { get; set; }
        public Gender? Gender { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        public int BrandID { get; set; }
        public Brand? Brand { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage ="Material is required")]
        public int MaterialID { get; set; }
        public Material? Material { get; set; }

        public bool? New { get; set; }
        public bool? Sale { get; set; }

        public ICollection<ProductLook>? ProductLooks { get; set; }

        [Required]
        public ICollection<ProductCategory>? ProductCategories { get; set; }
        public ICollection<ProductStyle> ProductStyles { get; set; } 
    }
}
