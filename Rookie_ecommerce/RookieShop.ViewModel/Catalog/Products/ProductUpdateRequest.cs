﻿using Microsoft.AspNetCore.Http;
using RookieShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RookieShop.ViewModel.Catalog.Products
{
    public class ProductUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal OriginalPrice { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public int ViewCount { get; set; }
        public string Details { set; get; }
        public IFormFile ThumnailImage { get; set; }
    }
}