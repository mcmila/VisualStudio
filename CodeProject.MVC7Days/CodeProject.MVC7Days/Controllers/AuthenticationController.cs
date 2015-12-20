using System.Web.Mvc;
using System.Web.Security;
using CodeProject.MVC7Days.BLL;
using CodeProject.MVC7Days.Models;

namespace CodeProject.MVC7Days.Controllers
{
    //Determina que o Controller não necessita de autenticação
    [AllowAnonymous]
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer bal = new EmployeeBusinessLayer();

                UserStatus status = bal.GetUserValidity(u);
                bool isAdmin;

                if (status == UserStatus.AuthenticatedAdmin)
                {
                    isAdmin = true;
                }
                else if (status == UserStatus.AuthentucatedUser)
                {
                    isAdmin = false;
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Invalid Username or Password");
                    return View("Login");
                }

                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["IsAdmin"] = isAdmin;

                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}