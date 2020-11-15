using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IProductRepository
    {
        Product GetProductById(int ProductId);
        Product GetProductByProductName(string productname);             
        IEnumerable<Product> GetProductListByCategory(int productCategoryId);
        IEnumerable<Product> GetProductListByName(string ProductName);
        IEnumerable<Product> ProductList();
        void Addproduct(Product product);
        void Editproduct(Product product);
        void RemoveProduct(Product product);
    }
}
