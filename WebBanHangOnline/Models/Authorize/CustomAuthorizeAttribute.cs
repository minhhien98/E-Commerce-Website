using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebBanHangOnline.Models.Authorize
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] allowedroles;
        private IUserService _userService;
        private IUserRoleRepository _userRoleRepository;
        public CustomAuthorizeAttribute(params string[] roles)
        {           
            this.allowedroles = roles;
            
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;            
            if (httpContext.User.Identity.IsAuthenticated)
            {
                _userService = DependencyResolver.Current.GetService<IUserService>();
                _userRoleRepository = DependencyResolver.Current.GetService<IUserRoleRepository>();
                var username = httpContext.User.Identity.Name;
                var user = _userService.GetUser(username);
                var userRole = _userRoleRepository.GetRoleById(user.RoleId);
                foreach (var role in allowedroles)
                {
                    if (role == userRole.Role) return true;
                }
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
               new RouteValueDictionary
               {
                    { "controller", "Home" },
                    { "action", "Index" }
               });
        }
    }
}