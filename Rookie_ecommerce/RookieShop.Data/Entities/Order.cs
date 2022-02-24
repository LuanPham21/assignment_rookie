using RookieShop.Data.Enums;

namespace RookieShop.Data.Entities
{
    public class Order
    {
        public int OrdersId { get; set; }
        public DateTime OrdersDate { get; set; }
        public int UserId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public int ShipPhoneNumber { get; set; }
        public Status Status { get; set; }
        public int Total { get; set; }

    }
}
