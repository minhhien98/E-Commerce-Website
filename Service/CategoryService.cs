using DomainModel.Entity;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CreateCat(Category category)
        {
            _categoryRepository.CrateCat(category);
        }

        public void DeleteCat(Category category)
        {
            _categoryRepository.DeleteCat(category);
        }

        public void EditCat(Category category)
        {
            _categoryRepository.EditCat(category);
        }

        public Category GetCategoryById(int id)
        {
            return _categoryRepository.GetCatById(id);
        }
        public IEnumerable<Category> CategoryList()
        {
            return _categoryRepository.CategoryList();
        }
    }
}
