namespace e_commerce.Models
{
    public class Look
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public ICollection<ProductLook>? ProductLooks { get; set; }
    }
}
