using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using DomainModel.Entity;
using Repository;
using Repository.Interface;
using Service;
using Service.Authentication;
using Service.Interface;
using Service.Interface.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.App_Start
{
    public class ContainerConfig
    {
       public static void CDInjection()
        {
            var Builder = new ContainerBuilder();
            //Builder.RegisterControllers(typeof(MvcApplication).Assembly);
            Builder.RegisterControllers(Assembly.GetExecutingAssembly());
            Builder.RegisterType<DatabaseContext>().InstancePerRequest();
            //Repository
            Builder.RegisterType<UserRepository>().As<IUserRepository>();
            Builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();        
            Builder.RegisterType<ProductCategoryRepository>().As<IProductCategoryRepository>();
            Builder.RegisterType<ProductRepository>().As<IProductRepository>();
            Builder.RegisterType<CartRepository>().As<ICartRepository>();
            Builder.RegisterType<UserRoleRepository>().As<IUserRoleRepository>();
            //Service
            Builder.RegisterType<UserService>().As<IUserService>();
            Builder.RegisterType<CategoryService>().As<ICategoryService>();
            Builder.RegisterType<ProductCategoryService>().As<IProductCategoryService>();
            Builder.RegisterType<ProductService>().As<IProductService>();
            Builder.RegisterType<CartService>().As<ICartService>();
            Builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            Builder.RegisterType<UserRoleService>().As<IUserRoleService>();
            Builder.Register(c => new HttpContextWrapper(HttpContext.Current)).As<HttpContextBase>().InstancePerRequest();
            //
            //Builder.RegisterType<IMapper>().SingleInstance();
            IContainer container = Builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}