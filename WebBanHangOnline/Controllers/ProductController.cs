using DomainModel.Entity;
using PagedList;
using Service;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using WebBanHangOnline.Models.Authorize;
using WebBanHangOnline.Models.Product;

namespace WebBanHangOnline.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productservice;
        private IUserService _userService;
        private IProductCategoryService _productCategoryService;  
        public ProductController(IProductService productService, IUserService userService,IProductCategoryService productCategoryService)
        {
            _productservice = productService;
            _userService = userService;
            _productCategoryService = productCategoryService;
        }      
        public ActionResult ProductListByCategory(int productCategoryId,int? page)
        {
            ViewBag.id = productCategoryId;
            var cat = _productCategoryService.GetProductCategoryById(productCategoryId);
            var vm = _productservice.GetProductListByCategory(productCategoryId).ToPagedList(page ?? 1,2);
            ViewBag.Title = cat.ProductCategoryName;
            return View(vm);
        }
        public ActionResult ProductDetail(int ProductId)
        {
            var product = _productservice.GetProductById(ProductId);
            return View(product);
        }

        public ActionResult SearchProductByName(string ProductName,int? page)
        {
            ViewBag.ProductName = ProductName;
            var vm = _productservice.GetProductListByName(ProductName).ToPagedList(page ?? 1,2);
            return View(vm);
        }

        //
        [Authorize(Roles = "Admin")]
        public ActionResult List()
        {
            var list = _productservice.ProductList();
            return View(list);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            CreateProductViewModel vm = new CreateProductViewModel()
            {
                ProductCategoryList = _productCategoryService.GetProductCategoryList()
            };
            return View(vm);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Create(CreateProductViewModel vm, Product product)
        {
            if (ModelState.IsValid)
            {
                if (_productservice.GetProductByProductName(vm.ProductName) != null)
                {
                    ViewBag.ExistedProduct = "Product already Existed";
                    vm.ProductCategoryList = _productCategoryService.GetProductCategoryList();
                    return View(vm);
                }
                var imgfile = Path.GetFileName(vm.ProductImage.FileName);
                var strpath = Server.MapPath("~/Content/Image/Product/");
                var pathToSave = Path.Combine(strpath, imgfile);
                vm.ProductImage.SaveAs(pathToSave);
                product.ProductImage = imgfile;
                _productservice.AddProduct(product);
                return RedirectToAction("Index", "Home");
            }
            vm.ProductCategoryList = _productCategoryService.GetProductCategoryList();
            return View(vm);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(int id)
        {
            var product = _productservice.GetProductById(id);
            var vm = new EditProductViewModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductDescription = product.ProductDescription,
                ProductCategoryList = _productCategoryService.GetProductCategoryList(),
            };
            return View(vm);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(EditProductViewModel vm, Product product)
        {
            if (ModelState.IsValid)
            {
                var imgfile = Path.GetFileName(vm.ProductImage.FileName);
                var strpath = Server.MapPath("~/Content/Image/Product/");
                var pathToSave = Path.Combine(strpath, imgfile);
                vm.ProductImage.SaveAs(pathToSave);
                product.ProductImage = imgfile;
                _productservice.EditProduct(product);
                return RedirectToAction("Index", "Home");
            }
            vm.ProductCategoryList = _productCategoryService.GetProductCategoryList();
            return View(vm);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Remove(int id)
        {
            var vm = _productservice.GetProductById(id);
            return View(vm);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Remove(Product vm)
        {
            var product = _productservice.GetProductById(vm.ProductId);
            if (product != null){
                var imgfile = product.ProductImage;
                var strpath = Server.MapPath("~/Content/Image/Product/" + imgfile);
                if (System.IO.File.Exists(strpath))
                {
                    System.IO.File.Delete(strpath);
                    _productservice.RemoveProduct(product);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(product);
                }
            }
            return HttpNotFound();
                       
        }
        public ActionResult Random3Products()
        {
            var list = _productservice.ProductList();
            return View(list);
        }
        public ActionResult RandomProductsByCategory()
        {
            //var list = _productservice.ProductList();
            var r = new Random();
            List<ProductCategory> catlist = _productCategoryService.GetProductCategoryList().ToList();
            var RandomCat = r.Next(catlist.Count());
            var list = _productservice.GetProductListByCategory(catlist[RandomCat].ProductCategoryId);
            return View(list);
        }
    }       
}