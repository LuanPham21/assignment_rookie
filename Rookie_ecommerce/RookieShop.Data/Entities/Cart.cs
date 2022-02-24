namespace RookieShop.Backend.Entities
{
    public class Cart
    {
        public int CartsID  { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
