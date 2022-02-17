using System;

namespace RookieShop.Backend.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string ImageName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
