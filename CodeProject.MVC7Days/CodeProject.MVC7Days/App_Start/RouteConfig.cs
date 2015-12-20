using System.Web.Mvc;
using System.Web.Routing;

namespace CodeProject.MVC7Days
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           // routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                "MyRoute",
                "Employee/List/{pEmpId}",
                new { controller = "Employee", action = "GetEmployeeById" },
                new { pEmpId = @"\d+" }      
            );

            routes.MapRoute(
            name: "Upload",
            url: "Employee/BulkUpload",
            defaults: new { controller = "BulkUpload", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
