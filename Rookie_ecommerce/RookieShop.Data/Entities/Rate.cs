using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.Data.Entities
{
    public class Rate
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public Guid UserId { get; set; }
        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}