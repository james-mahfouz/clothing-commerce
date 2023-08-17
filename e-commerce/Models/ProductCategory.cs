namespace e_commerce.Models
{
    public class ProductCategory
    {

        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int SubCategoryID { get; set; }
        public int ProductID { get; set; }

        public Category? Category { get; set; }
        public SubCategory? SubCategory { get; set; }
        public Product? Product { get; set; }

        
    }
}
