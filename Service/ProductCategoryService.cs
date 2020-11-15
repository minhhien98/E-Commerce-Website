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
    public class ProductCategoryService :IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public void Create(ProductCategory productCategory)
        {
            _productCategoryRepository.Create(productCategory);
        }

        public void Delete(ProductCategory productCategory)
        {
            _productCategoryRepository.Delete(productCategory);
        }

        public void Edit(ProductCategory productCategory)
        {
            _productCategoryRepository.Edit(productCategory);
        }

        public ProductCategory GetProductCategoryById(int id)
        {
            return _productCategoryRepository.GetProductCategoryById(id);
        }

        public IEnumerable<ProductCategory> GetProductCategoryList()
        {
            return _productCategoryRepository.GetProductCategoryList();
        }
    }
}
