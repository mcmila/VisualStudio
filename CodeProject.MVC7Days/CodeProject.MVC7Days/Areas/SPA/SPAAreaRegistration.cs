using System.Web.Mvc;

namespace CodeProject.MVC7Days.Areas.SPA
{
    public class SPAAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "SPA";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SPA_default",
                "SPA/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}