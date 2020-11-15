using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public int ProductCategoryId { get; set; }
        [Required]
        public string ProductCategoryName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public IEnumerable<Category> Category { get; set; }
    }
}