using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.Common
{
    public class Cart
    {
        public DomainModel.Entity.Product product { get; set; }
        public int Quantity { get; set; }
        /*public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }

        public int ProductCategoryId { get; set; }*/
    }
}