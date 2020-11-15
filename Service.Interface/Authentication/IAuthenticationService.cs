using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service.Interface.Authentication
{
    public interface IAuthenticationService
    {
        bool Login(string username, string password, bool RememberMe);
        void Logout();
        void AddSession(string user_session, string user);
        void RemoveSession(string currentsession);
        void AddCookie(string username, bool RememberMe);
        void RemoveCookie();       
    }
}
