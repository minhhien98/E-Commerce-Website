using DomainModel.Entity;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserRoleService : IUserRoleService
    {
        private IUserRoleRepository _userRoleRepository;
        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }
        public void AddRole(UserRole userRole)
        {
            _userRoleRepository.AddRole(userRole);
        }

        public void DeleteRole(UserRole userRole)
        {
            _userRoleRepository.DeleteRole(userRole);
        }

        public void EditRole(UserRole userRole)
        {
            _userRoleRepository.EditRole(userRole);
        }

        public UserRole GetRoleById(int id)
        {
            return _userRoleRepository.GetRoleById(id);
        }

        public IEnumerable<UserRole> RoleList()
        {
            return _userRoleRepository.RoleList();
        }
    }
}
