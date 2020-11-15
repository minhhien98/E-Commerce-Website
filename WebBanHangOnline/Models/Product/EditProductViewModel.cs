using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DomainModel.Entity;

namespace WebBanHangOnline.Models.Product
{
    public class EditProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public HttpPostedFileBase ProductImage { get; set; }

        [Required]
        public int ProductCategoryId { get; set; }
        public IEnumerable<DomainModel.Entity.ProductCategory> ProductCategoryList { get; set; }
    }
}