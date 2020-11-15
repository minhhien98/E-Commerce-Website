using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICategoryRepository
    {
        void CrateCat(Category category);
        void EditCat(Category category);
        void DeleteCat(Category category);
        Category GetCatById(int id);
        IEnumerable<Category> CategoryList();
    }
}
