namespace RookieShop.Data.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }
        public int ProductId { get; set; }
        public DateTime DateCreate { get; set; }
        public int SortOrder { get; set; }
        public string Caption { get; set; }
        public Product Product { get; set; }
    }
}