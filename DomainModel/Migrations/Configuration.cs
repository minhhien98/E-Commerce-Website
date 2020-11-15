namespace DomainModel.Migrations
{
    using DomainModel.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DomainModel.Entity.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DomainModel.Entity.DatabaseContext context)
        {
            context.Categories.AddOrUpdate(
                c =>c.CategoryName,
                new Category { CategoryId =1, CategoryName = "Linh kiện máy tính" },
                new Category { CategoryId=2, CategoryName = "Điện tử - điện lạnh" }
                );

            context.ProductCategories.AddOrUpdate(
                pc => pc.ProductCategoryName,
                new ProductCategory { ProductCategoryId = 1, ProductCategoryName = "Bàn phím", CategoryId =1 },
                new ProductCategory { ProductCategoryId = 2, ProductCategoryName = "Chuột máy tính", CategoryId = 1},
                new ProductCategory { ProductCategoryId = 3, ProductCategoryName = "Máy lạnh", CategoryId = 2 }
                );

            context.Products.AddOrUpdate(
                p =>p.ProductName,
                new Product { ProductName ="Bàn phím R8-1822", ProductPrice = 500000, ProductDescription ="Bàn phím r8-1822", ProductImage= "BanPhim-R8-1822-1.jpg", ProductCategoryId = 1 },
                new Product { ProductName = "Bàn phím cơ e-dra", ProductPrice = 600000, ProductDescription = "Bàn phím cơ e-dra", ProductImage = "Ban phim co E-dra.jpg", ProductCategoryId = 1 },
                new Product { ProductName = "Bàn phím Fuhlen L411", ProductPrice = 500000, ProductDescription = "Bàn phím Fuhlen L41", ProductImage = "BanPhim Game Fuhlen L411.jpg", ProductCategoryId = 1 },
                new Product { ProductName = "Chuột Không Dây Logitech M331 Silent Plus", ProductPrice = 284000, ProductDescription = "Chuột Không Dây Logitech M331 Silent Plus", ProductImage = "Chuot khong day logitech M331.jpg", ProductCategoryId = 2 },
                new Product { ProductName = "Chuột không dây 6 nút IceFox", ProductPrice = 260000, ProductDescription = "Chuột không dây 6 nút IceFox", ProductImage = "Chuot khong day IceFox.jpg", ProductCategoryId = 2 },
                new Product { ProductName = "Máy Lạnh ALASKA INVERTER", ProductPrice = 8000000, ProductDescription = "Máy Lạnh ALASKA INVERTER", ProductImage = "May lanh Alaska.jpg", ProductCategoryId = 3 },
                new Product { ProductName = "Máy lạnh Kooda 1.0 HP S09N55", ProductPrice = 4690000, ProductDescription = "Máy lạnh Kooda 1.0 HP S09N55", ProductImage = "May lanh Kooda.jpg", ProductCategoryId = 3 }
            );

            context.userRoles.AddOrUpdate(
                r => r.Role,
                new UserRole { RoleId = 1, Role = "Admin" },
                new UserRole { RoleId = 2, Role = "User"}
                );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
