using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entity
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }       
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        //public ICollection<Product> Product { get; set; }        
    }
}
