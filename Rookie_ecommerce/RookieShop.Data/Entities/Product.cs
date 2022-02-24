using RookieShop.Data.Enums;

namespace RookieShop.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime TimeCreate { get; set; }
        public Status Status { get; set; }
        public int ViewCount { get; set; }
        public string Details { set; get; }
        public List<ProductsInCategory> ProductsInCategories { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Image> Images { get; set; }
    }
}
