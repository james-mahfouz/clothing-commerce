namespace e_commerce.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
