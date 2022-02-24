namespace RookieShop.Backend.Entities
{
    public class Order
    {
        public int OrdersID { get; set; }
        public DateTime OrdersDate { get; set; }
        public int UserID { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public int ShipPhoneNumber { get; set; }
        public string Status { get; set; }
        public int Total { get; set; }

    }
}
