namespace RookieShop.Data.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
