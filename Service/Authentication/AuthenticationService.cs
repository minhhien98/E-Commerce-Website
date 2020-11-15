using Repository.Interface;
using Repository;
using Service.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utility;
using System.Security.Claims;
using System.Web.Security;
using Microsoft.Owin;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Routing;

namespace Service.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private IUserRepository _userrepository;
        private IUserRoleRepository _userRoleRepository;
        private HttpContextBase _context;
        public AuthenticationService(IUserRepository userRepository, IUserRoleRepository userRoleRepository,HttpContextBase context)
        {
            _userrepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _context = context;
        }
        /*public AuthenticationService(IUserRepository iuserrepository)
        {
            _repository = iuserrepository;
        }*/

        public bool Login(string username, string password, bool RememberMe)
        {
            string hashpass = PasswordHelper.Sha256(password, username);
            var user = _userrepository.GetAll().FirstOrDefault(x => x.UserName == username && x.Password == hashpass);
            
            if (user != null)
            {
                var role = _userRoleRepository.GetRoleById(user.RoleId).Role;
                var userClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name , user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role),
            };
                var ClaimIdentity = new ClaimsIdentity(userClaims, DefaultAuthenticationTypes.ApplicationCookie);
                //var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                var ctx = _context.Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(new AuthenticationProperties()
                {
                    ExpiresUtc = DateTime.UtcNow.AddDays(200),
                    IsPersistent = RememberMe,
                }, ClaimIdentity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Logout()
        {
            IOwinContext context = _context.Request.GetOwinContext();
            IAuthenticationManager authenticationManager = context.Authentication;

            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
        public void AddSession(string user_session, string user)
        {
            HttpContext.Current.Session.Add(user_session, user);         
        }
        public void RemoveSession(string currentsession)
        {
            if (currentsession != null)
            {
                HttpContext.Current.Session.Remove(currentsession);
            }
        }

        public void AddCookie(string username, bool RememberMe)
        {
            if (RememberMe)
            {
                HttpCookie usercookie = new HttpCookie("usercookie",username);
                usercookie.Expires = DateTime.Now.AddHours(1);
                HttpContext.Current.Response.SetCookie(usercookie);
            }
            else
            {
                HttpCookie usercookie = new HttpCookie("usercookie",username);
                HttpContext.Current.Response.SetCookie(usercookie);
            }
        }
        public void RemoveCookie()
        {
            HttpCookie usercookie = HttpContext.Current.Request.Cookies["usercookie"];
            if (usercookie != null)
            {
                HttpCookie mycookie = new HttpCookie("usercookie");
                mycookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(mycookie);
            }
        }
    }
}
