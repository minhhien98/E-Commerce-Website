using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory productCategory);
        void Edit(ProductCategory productCategory);
        void Delete(ProductCategory productCategory);
        IEnumerable<ProductCategory> GetProductCategoryList();
        ProductCategory GetProductCategoryById(int id);



    }
}
