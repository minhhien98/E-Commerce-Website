using DomainModel.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private DatabaseContext _context;
        public UserRoleRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddRole(UserRole userRole)
        {
            _context.userRoles.Add(userRole);
            _context.SaveChanges();
        }

        public void DeleteRole(UserRole userRole)
        {
            _context.userRoles.Remove(userRole);
            _context.SaveChanges();
        }

        public void EditRole(UserRole userRole)
        {
            _context.Entry(userRole).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public UserRole GetRoleById(int id)
        {
            return _context.userRoles.Find(id);
        }
        public IEnumerable<UserRole> RoleList()
        {
            return _context.userRoles.ToList();
        }
    }
}
