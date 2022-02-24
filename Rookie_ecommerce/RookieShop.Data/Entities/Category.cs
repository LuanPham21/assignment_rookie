using RookieShop.Data.Enums;

namespace RookieShop.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Status Status { get; set; }
        public List<ProductsInCategory> ProductsInCategories { get; set; }

    }
}
