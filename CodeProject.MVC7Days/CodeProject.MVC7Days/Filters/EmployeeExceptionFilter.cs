using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeProject.MVC7Days.Logger;

namespace CodeProject.MVC7Days.Filters
{
    public class EmployeeExceptionFilter : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            FileLogger logger = new FileLogger();
            logger.LogException(filterContext.Exception);
            base.OnException(filterContext);

            //filterContext.ExceptionHandled = true;
            //filterContext.Result = new ContentResult()
            //{
            //    Content = "Sorry for the Error"
            //};
        }
    }
}