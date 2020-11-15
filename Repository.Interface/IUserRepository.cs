using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetUserByUserName(string username);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
