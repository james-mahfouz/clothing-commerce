namespace e_commerce.Models
{
    public class Size
    {
        public int ID { get; set; }
        public int SizeNumber { get; set; }

        public ICollection<ProductStyle>? ProductStyles { get; set; }
    }
}
