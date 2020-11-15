using DomainModel.Entity;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models.Authorize;

namespace WebBanHangOnline.Controllers
{
    [CustomAuthorize("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cat)
        {
            _categoryService.CreateCat(cat);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category cat) 
        {
            if(cat != null)
            {
                _categoryService.EditCat(cat);
                return RedirectToAction("index", "home");
            }
            return HttpNotFound();
        }
        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            category = _categoryService.GetCategoryById(category.CategoryId);
            if(category != null)
            {
                _categoryService.DeleteCat(category);
                return RedirectToAction("index", "home");
            }
            return View(category);
        }
        public ActionResult List()
        {
            var list = _categoryService.CategoryList();
            return View(list);
        }
    }
}