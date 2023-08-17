namespace e_commerce.Models
{
    public class Material
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
