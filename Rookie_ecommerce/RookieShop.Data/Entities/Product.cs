using RookieShop.Data.Enums;

namespace RookieShop.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreate { get; set; }
        public Status Status { get; set; }

    }
}
