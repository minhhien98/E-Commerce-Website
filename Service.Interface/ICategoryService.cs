using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICategoryService
    {
        void CreateCat(Category category);
        void EditCat(Category category);
        void DeleteCat(Category category);
        Category GetCategoryById(int id);
        IEnumerable<Category> CategoryList();
    }
}
