using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        IEnumerable<User> Listuser();
        User GetUser(string username);
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(User user);
        int RoleAcess(string username);
    }
}
