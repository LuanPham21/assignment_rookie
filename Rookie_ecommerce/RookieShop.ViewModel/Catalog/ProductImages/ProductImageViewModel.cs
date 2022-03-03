using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.ViewModel.Catalog.ProductImages
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public string ImageLink { get; set; }
        public int ProductId { get; set; }
        public DateTime DateCreate { get; set; }
        public int SortOrder { get; set; }
        public string Caption { get; set; }
    }
}