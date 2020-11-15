using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entity
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}
