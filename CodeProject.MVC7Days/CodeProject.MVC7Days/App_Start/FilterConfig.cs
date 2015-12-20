using System.Web.Mvc;
using CodeProject.MVC7Days.Filters;

namespace CodeProject.MVC7Days
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new EmployeeExceptionFilter());
            //Determina que todos os Controllers necessitem de autenticação.
            //filters.Add(new AuthorizeAttribute());
            //filters.Add(new HandleErrorAttribute { View = "MyError" }); Mudar nome da view de Erro
        }
    }
}
