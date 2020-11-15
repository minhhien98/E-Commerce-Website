using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductService
    {
        Product GetProductById(int ProductId);
        Product GetProductByProductName(string productname);
        IEnumerable<Product> GetProductListByCategory(int productCategoryId);
        IEnumerable<Product> GetProductListByName(string ProductName);
        IEnumerable<Product> ProductList();
        void AddProduct(Product product);
        void EditProduct(Product product);
        void RemoveProduct(Product product);
    }
}
