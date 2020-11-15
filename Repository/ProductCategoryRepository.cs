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
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private DatabaseContext _context;
        public ProductCategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Create(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
        }

        public void Delete(ProductCategory productCategory)
        {
            _context.ProductCategories.Remove(productCategory);
            _context.SaveChanges();
        }

        public void Edit(ProductCategory productCategory)
        {
            _context.Entry(productCategory).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            return _context.ProductCategories.Include("Category").FirstOrDefault(p=>p.ProductCategoryId == id);
        }

        public IEnumerable<ProductCategory> GetProductCategoryList()
        {
            return _context.ProductCategories.Include("Category").ToList();
        }
    }
}
