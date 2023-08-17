using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class ProductStyle
    {
        public int ID { get; set; }
        public string? ProductImageLink { get; set; }
        public int Quantity { get; set; }

        public int ProductID { get; set; }
        public Product? Product { get; set; }
        [Required]
        public int ColorID { get; set; }
        public Color Color { get; set; }
        [Required]
        public int SizeID { get; set; }
        public Size Size { get; set; }

        //[Required]
        //public ICollection<ProductColor>? ProductColors { get; set; }
        //[Required]
        //public ICollection<ProductSize>? ProductSizes { get; set; }
        public ICollection<ShoppingCart>? ShoppingCarts { get; set; }

    }
}
