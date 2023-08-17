namespace e_commerce.Models
{
    public class ShoppingCart
    {
        public int ID { get; set; }
        public int ProductStyleID { get; set; }
        public ProductStyle? ProductStyle{ get; set;}
        //public int UserID { get; set; }
        //public User User { get; set; }
        public int ItemQuantity { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
