using DomainModel.Entity;
using Repository;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;
        public UserService(IUserRepository userRepository)
        {
            _repository = userRepository;
        }
        /*public UserService(IUserRepository iuserrepository)
        {
            _repository = iuserrepository;
        }*/

        public IEnumerable<User> Listuser()
        {
            return _repository.GetAll();
        }
        public User GetUser(string username)
        {
            return _repository.GetUserByUserName(username);
        }
        public void AddUser(User user)
        {
            _repository.AddUser(user);
        }
        public void EditUser(User user)
        {
            _repository.UpdateUser(user);
        }
        public void DeleteUser(User user)
        {
            _repository.DeleteUser(user);
        }

        public int RoleAcess(string username)
        {
            if(username != null)
            {
                var user = _repository.GetUserByUserName(username);
                return user.RoleId;
            }
            return -1;
        }
    }
}
