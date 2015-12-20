using System;
using System.Web.Mvc;

namespace CodeProject.MVC7Days.Models.ModelBinder
{
    public class MyEmployeeModelBinder : DefaultModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            Employee e = new Employee();
            e.FirstName = controllerContext.RequestContext.HttpContext.Request.Form["FName"];
            e.LastName = controllerContext.RequestContext.HttpContext.Request.Form["LName"];
            e.Salary = int.Parse(controllerContext.RequestContext.HttpContext.Request.Form["Salary"]);
            return e;
        }
    }
}