using System.Web.Mvc;
using System.Web.Routing;
using WebBanHangOnline.App_Start;

namespace WebBanHangOnline
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ContainerConfig.CDInjection();
            MappingConfig.RegisterMapping();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);           
        }
    }
}
