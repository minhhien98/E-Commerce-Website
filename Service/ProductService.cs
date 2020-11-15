using DomainModel.Entity;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository,IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
        }
        public Product GetProductById(int ProductId)
        {
            return _productRepository.GetProductById(ProductId);
        }
        public Product GetProductByProductName(string productname)
        {
            return _productRepository.GetProductByProductName(productname);
        }
        public IEnumerable<Product> GetProductListByCategory(int productCategoryId)
        {
            return _productRepository.GetProductListByCategory(productCategoryId);
        }
        public IEnumerable<Product> GetProductListByName(string ProductName)
        {
            return _productRepository.GetProductListByName(ProductName);
        }
        public void AddProduct(Product product)
        {
            _productRepository.Addproduct(product);
        }

        public void EditProduct(Product product)
        {
            _productRepository.Editproduct(product);
        }

        public void RemoveProduct(Product product)
        {
            _productRepository.RemoveProduct(product);
        }

        public IEnumerable<Product> ProductList()
        {
            return _productRepository.ProductList();
        }
    }
}
