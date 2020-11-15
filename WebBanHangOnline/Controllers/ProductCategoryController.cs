using AutoMapper;
using DomainModel.Entity;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.App_Start;
using WebBanHangOnline.Models.Authorize;
using WebBanHangOnline.Models.ProductCategory;

namespace WebBanHangOnline.Controllers
{
    public class ProductCategoryController : Controller
    {
        private IProductCategoryService _productCategoryService;
        private ICategoryService _categoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService,ICategoryService categoryService)
        {
            _productCategoryService = productCategoryService;
            _categoryService = categoryService;
        }
        // GET: ProductCategory
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ProductCategoryViewModel vm = new ProductCategoryViewModel()
            {
                Category = _categoryService.CategoryList(),
            };
            return View(vm);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Create(ProductCategoryViewModel vm,ProductCategory productCategory)
        {
            if(!ModelState.IsValid)
            {
                vm.Category = _categoryService.CategoryList();
                return View(vm);
            }
            _productCategoryService.Create(productCategory);
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles ="Admin")]
        public ActionResult List()
        {
            var list = _productCategoryService.GetProductCategoryList();
            return View(list);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(int id)
        {
            var cat = _productCategoryService.GetProductCategoryById(id);
            ProductCategoryViewModel vm = new ProductCategoryViewModel()
            {
                ProductCategoryId = cat.ProductCategoryId,
                ProductCategoryName = cat.ProductCategoryName,
                Category = _categoryService.CategoryList(),
            };
            return View(vm);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(ProductCategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Category = _categoryService.CategoryList();
                return View(vm);
            }
            var cat = MappingConfig.mapping.Map<ProductCategory>(vm);
            _productCategoryService.Edit(cat);
            return RedirectToAction("List", "ProductCategory");
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int id)
        {
            var cat = _productCategoryService.GetProductCategoryById(id);
            if(cat != null)
            {
                return View(cat);
            }
            return HttpNotFound();
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(ProductCategory vm)
        {
            var cat = _productCategoryService.GetProductCategoryById(vm.ProductCategoryId);
            _productCategoryService.Delete(cat);
            return RedirectToAction("List", "ProductCategory");
        }
        public ActionResult PCategoryListNav()
        {
            var list = _productCategoryService.GetProductCategoryList();
            return View(list);
        }
    }
}