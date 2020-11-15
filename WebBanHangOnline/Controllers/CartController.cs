using DomainModel.Entity;
using Service;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Models.Common;

namespace WebBanHangOnline.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productservice;
        private ICartService _cartservice;
        public CartController(IProductService productService,ICartService cartService)
        {
            _productservice = productService;
            _cartservice = cartService;
        }
        // GET: Cart
        public ActionResult Index()
        {
            if (Session["Cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public ActionResult AddtoCart(int id)
        {

            List<Cart> list;
            
            if (Session["Cart"] != null)
            {
                list = (List<Cart>)Session["Cart"];
                int index = isExist(id);
                if(index != -1)
                {
                    list[index].Quantity++;
                }
                else
                {
                    list.Add(new Cart { product = _productservice.GetProductById(id), Quantity = 1 });
                }                                                    
            }                  
            else
            {
                list = new List<Cart>();
                list.Add(new Cart { product = _productservice.GetProductById(id), Quantity = 1 });                
            }
            Session["Cart"] = list;            
            ViewBag.listcount = list.Count;
            return RedirectToAction("Index","Cart");
        }
        public ActionResult UpdateQuantity(int id,int quantity)
        {
            List<Cart> list;
            if (Session["Cart"] != null)
            {
                list = (List<Cart>)Session["Cart"];
                int index = isExist(id);
                if(index != -1)
                {
                    list[index].Quantity = quantity;
                    if(list[index].Quantity == 0)
                    {
                        list.RemoveAt(index);
                        Session["Cart"] = list;
                        if (list.Count == 0)
                        {
                            Session.Remove("Cart");
                            return RedirectToAction("Index", "Home");
                        }
                    }                   
                }
                Session["Cart"] = list;                             
            }          
            return RedirectToAction("Index", "Cart");
        }

        public ActionResult RemoveFromCart(int id)
        {
            List<Cart> list = (List<Cart>)Session["Cart"];
            int index = isExist(id);
            list.RemoveAt(index);
            Session["Cart"] = list;           
            if ( list.Count != 0)
            {
                return RedirectToAction("Index", "Cart");               
            }
            else
            {
                Session.Remove("Cart");
                return RedirectToAction("Index", "Home");
            }      
        }
        [Authorize]
        [HttpPost]
        public ActionResult Checkout()
        {
            double total = 0;
            List<Cart> list = (List<Cart>)Session["cart"];
            Bill b = new Bill();
            BillDetail bd;
            foreach(var item in list)
            {                
                total +=(item.product.ProductPrice * item.Quantity);                
            }
            _cartservice.bill(b,total, User.Identity.Name);
            foreach(var item in list)
            {
                bd = new BillDetail();
                bd.BillId = b.BillId;
                bd.ProductId = item.product.ProductId;
                bd.ProductName = item.product.ProductName;
                bd.Price = item.product.ProductPrice;
                bd.ProductQuantity = item.Quantity;
                _cartservice.billdetail(bd);
            }
            Session.Remove("cart");
            return RedirectToAction("Index","Home");
        }
        private int isExist(int id)
        {
            List<Cart> cart = (List<Cart>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].product.ProductId.Equals(id))
                    return i;
            return -1;
        }
    }   
}