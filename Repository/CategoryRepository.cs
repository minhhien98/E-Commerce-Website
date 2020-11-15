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
    public class CategoryRepository : ICategoryRepository
    {
        private DatabaseContext _context;
        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void CrateCat(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCat(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void EditCat(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Category GetCatById(int id)
        {
            return _context.Categories.Find(id);
        }
        public IEnumerable<Category> CategoryList()
        {
            return _context.Categories.ToList();
        }
    }
}
