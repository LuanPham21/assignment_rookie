using RookieShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.ViewModel.Catalog.Categories
{
    public class CategoriesCreateRequest
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public Status Status { get; set; }
    }
}