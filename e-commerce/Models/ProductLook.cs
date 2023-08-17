namespace e_commerce.Models
{
    public class ProductLook
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int LookID { get; set; }
        public Product? Product { get; set; }
        public Look? Look { get; set; }
    }
}
