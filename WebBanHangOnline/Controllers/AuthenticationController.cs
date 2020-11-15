using Repository;
using Service;
using Service.Authentication;
using Service.Interface;
using Service.Interface.Authentication;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utility;
using WebBanHangOnline.Models.Authentication;
using WebBanHangOnline.Models.Common;

namespace WebBanHangOnline.Controllers
{
    public class AuthenticationController : Controller
    {
        private IAuthenticationService _authenticationservice;        
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationservice = authenticationService;
        }


        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {                
                var result = _authenticationservice.Login(model.UserName, model.Password, model.RememberMe);
                if (result)
                {                   
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Password", "Invalid User");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            _authenticationservice.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}