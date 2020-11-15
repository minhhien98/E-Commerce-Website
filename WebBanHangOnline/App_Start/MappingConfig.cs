using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DomainModel.Entity;
using WebBanHangOnline.Models.Product;
using WebBanHangOnline.Models.ProductCategory;
using WebBanHangOnline.Models.User;

namespace WebBanHangOnline.App_Start
{
    public class MappingConfig : Profile
    {
        public static IMapper mapping;
        public static void RegisterMapping()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, RegisterViewModel>().ReverseMap();
                config.CreateMap<User, UserViewModel>().ReverseMap();
                config.CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();

            });
            mapping = mapperConfig.CreateMapper();
        }
    }
}