using System.ComponentModel.DataAnnotations;

namespace e_commerce.Requests
{
    public class AddProductToCartRequest
    {
        [Required]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        public int Color { get; set; }

        [Required(ErrorMessage = "Size is required.")]
        public int Size { get; set; }
    }
}
