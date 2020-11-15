using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductCategoryService
    {
        void Create(ProductCategory productCategory);
        void Edit(ProductCategory productCategory);
        void Delete(ProductCategory productCategory);
        ProductCategory GetProductCategoryById(int id);
        IEnumerable<ProductCategory> GetProductCategoryList();
    }
}
