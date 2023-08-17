namespace e_commerce.Models
{
    public class Order
    {
        public int ID { get; set; }
        public bool isBought { get; set; }
        public float price { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
