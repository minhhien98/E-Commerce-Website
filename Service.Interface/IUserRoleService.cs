using DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserRoleService
    {
        void AddRole(UserRole userRole);
        void EditRole(UserRole userRole);
        void DeleteRole(UserRole userRole);
        UserRole GetRoleById(int id);
        IEnumerable<UserRole> RoleList();
    }
}
