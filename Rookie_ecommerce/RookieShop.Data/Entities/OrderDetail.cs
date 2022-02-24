namespace RookieShop.Backend.Entities
{
    public class OrderDetail
    {
        public int OrderDetailsID { get; set; }
        public int OrdersID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

    }
}
