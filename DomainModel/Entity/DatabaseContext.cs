using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Entity
{
    public class DatabaseContext :DbContext
    {
        public DatabaseContext() : base("name=WebBanHangOnline")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> userRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillDetail>().HasRequired(b => b.Bill).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<BillDetail>().HasRequired(p=>p.Product).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}

