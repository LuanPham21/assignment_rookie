namespace RookieShop.Data.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrdersId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
