using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeProject.MVC7Days.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        //[HandleError(View = "MyError")] Mudar nome da view de Erro
        public ActionResult Index()
        {
            Exception e = new Exception("Invalid Controller or/and Action Name");
            HandleErrorInfo eInfo = new HandleErrorInfo(e, "Unknown", "Unknown");
            return View("Error", eInfo);
        }
    }
}