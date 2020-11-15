using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.Product
{
    public class ProductListByCategoryViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }

        public int ProductCategoryId { get; set; }
        public DomainModel.Entity.ProductCategory ProductCategory { get; set; }
    }
}