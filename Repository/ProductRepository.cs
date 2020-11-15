using DomainModel.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private DatabaseContext _context;
        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }
        public Product GetProductById(int ProductId)
        {
            return _context.Products.Include("ProductCategory").SingleOrDefault(p=>p.ProductId == ProductId);
        }
        public Product GetProductByProductName(string productname)
        {
            return _context.Products.Include("ProductCategory").SingleOrDefault(p => p.ProductName == productname);
        }

        public IEnumerable<Product> GetProductListByCategory(int productCategoryId)
        {
            return _context.Products.ToList().Where(x => x.ProductCategoryId == productCategoryId);
        }

        public IEnumerable<Product> GetProductListByName(string ProductName)
        {
            var product = from p in _context.Products where p.ProductName.Contains(ProductName) orderby p.ProductName select p;
            return product;
        }
        public void Addproduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Editproduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> ProductList()
        {
            return _context.Products.Include("ProductCategory").ToList();
        }
    }
}
