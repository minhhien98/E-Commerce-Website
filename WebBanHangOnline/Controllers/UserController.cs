using DomainModel.Entity;
using Service.Interface;
using System.Linq;
using System.Web.Mvc;
using Utility;
using WebBanHangOnline.App_Start;
using WebBanHangOnline.Models.User;

namespace WebBanHangOnline.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userservice;
        private IUserRoleService _userRoleService;
        public UserController(IUserService userService,IUserRoleService userRoleService)
        {
            _userservice = userService;
            _userRoleService = userRoleService;
        }
        // GET: User 
        [Authorize(Roles ="Admin")]
        public ActionResult UserList()
        {
            var list = _userservice.Listuser();
            return View(list);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            UserViewModel vm = new UserViewModel()
            {
                userRole = _userRoleService.RoleList(),
            };
            return View(vm);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Password = PasswordHelper.Sha256(vm.Password, vm.UserName);
                var user = MappingConfig.mapping.Map<User>(vm);               
                _userservice.AddUser(user);
                return RedirectToAction("UserList", "User");
            }
            vm.userRole = _userRoleService.RoleList();
            return View(vm);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(string username)
        {
            var user = _userservice.GetUser(username);
            if(user != null)
            {
                //var vm = MappingConfig.mapping.Map<UserViewModel>(user);
                //vm.userRole = _userRoleService.RoleList();
                var vm = new UserViewModel()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Phone = user.Phone,
                    RoleId = user.RoleId,
                    userRole = _userRoleService.RoleList(),
                };
                return View(vm);
            }
            return HttpNotFound();           
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(UserViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = MappingConfig.mapping.Map<User>(vm);
                _userservice.EditUser(user);
                return RedirectToAction("UserList", "User");
            }
            vm.userRole = _userRoleService.RoleList();
            return View(vm);
        }
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(string username)
        {
            var user = _userservice.GetUser(username);            
            return View(user);
        }
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(User vm)
        {
            var user = _userservice.GetUser(vm.UserName);
            if(user != null)
            {
                _userservice.DeleteUser(user);
                return RedirectToAction("UserList", "User");
            }
            return HttpNotFound();
        }
        //
        public ActionResult ChangePassword()
        {           
            if(HttpContext.Request.Cookies["usercookie"] != null)
            {
               
                return View();
            }
            {
                return RedirectToAction("Login", "Authentication");
            }
            
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel vm)
        {
            var user = _userservice.GetUser(HttpContext.Request.Cookies["usercookie"].Value);
            if (ModelState.IsValid)
            {
                if(PasswordHelper.Sha256(vm.OldPassword,user.UserName) != user.Password)
                {
                    ViewBag.WrongPass = "Wrong Password";
                    return View();
                }
                user.Password = PasswordHelper.Sha256(vm.NewPassword, user.UserName);
                _userservice.EditUser(user);
                return RedirectToAction("Index", "Home");
            }
            return View(vm);
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterViewModel vm)
        {
            var userexist = _userservice.Listuser().Any(u => u.UserName == vm.UserName);
            if (userexist)
            {
                ModelState.AddModelError("UserName", "User name already existed");
                return View();
            }
            if (ModelState.IsValid)
            {
                vm.Password = PasswordHelper.Sha256(vm.Password, vm.UserName);
                /*basic mapping*/
                var user = MappingConfig.mapping.Map<User>(vm);
                user.RoleId = 2;
                _userservice.AddUser(user);
                return RedirectToAction("Login", "Authentication");
            }
            return View(vm);
        }
    }
}