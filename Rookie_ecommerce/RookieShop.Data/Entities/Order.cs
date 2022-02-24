using RookieShop.Data.Enums;

namespace RookieShop.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrdersDate { get; set; }
        public Guid UserId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public int ShipPhoneNumber { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}
