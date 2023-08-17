namespace e_commerce.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }
    }
}
