using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.ViewModel.Catalog.Products
{
    public class RatingVM
    {
        public int Rating { get; set; }
        public string Description { get; set; }
        public int ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}