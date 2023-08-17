using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    public class Brand
    {
        public int ID { get; set; }
        [Required] public string? Title { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
