namespace RookieShop.Backend.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreate { get; set; }
        public string Status { get; set; }

    }
}
