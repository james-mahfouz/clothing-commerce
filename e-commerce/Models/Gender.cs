namespace e_commerce.Models
{
    public class Gender
    {
        public int Id { get; set; } 
        public string? Title { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
