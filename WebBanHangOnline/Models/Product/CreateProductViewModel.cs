using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.Models.Product
{
    public class CreateProductViewModel
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