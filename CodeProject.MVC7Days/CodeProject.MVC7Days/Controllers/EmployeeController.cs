using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CodeProject.MVC7Days.BLL;
using CodeProject.MVC7Days.Filters;
using CodeProject.MVC7Days.Models;
using CodeProject.MVC7Days.ViewModels;

namespace CodeProject.MVC7Days.Controllers
{
    //Determina que o Controller necessita de autenticação
    [Authorize]
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        [Authorize]
        [HeaderFooterFilter]
        [Route("Employee/List")]
        public ActionResult Index()
        {
            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeId = emp.EmployeeId;
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.Value.ToString("C");
                empViewModel.SalaryColor = emp.Salary > 15000 ? "yellow" : "green";
                empViewModels.Add(empViewModel);
            }

            employeeListViewModel.Employees = empViewModels;

            return View("Index", employeeListViewModel);
        }

        [ChildActionOnly]
        public ActionResult GetAddNewLink()
        {
            if (Convert.ToBoolean(Session["IsAdmin"]))
            {
                return PartialView("AddNewLink");
            }
            else
            {
                return new EmptyResult();
            }
        }

        [AdminFilter]
        [HeaderFooterFilter]
        public ActionResult AddNew()
        {
            CreateEmployeeViewModel employeeListViewModel = new CreateEmployeeViewModel();
            return View("CreateEmployee", employeeListViewModel);
        }

        [AdminFilter]
        [HeaderFooterFilter]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary.HasValue)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }

                        return View("CreateEmployee", vm);
                    }
                case "Cancel":
                    return RedirectToAction("Index", "Employee");
            }
            return new EmptyResult();
        }

        //----------3.1----------
        //public ActionResult SaveEmployee()
        //{
        //    Employee e = new Employee();
        //    e.FirstName = Request.Form["FName"];
        //    e.LastName = Request.Form["LName"];
        //    e.Salary = int.Parse(Request.Form["Salary"]);

        //    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
        //}

        //----------3.2----------
        //public ActionResult SaveEmployee(string FName, string LName, int Salary)
        //{
        //    Employee e = new Employee();
        //    e.FirstName = FName;
        //    e.LastName = LName;
        //    e.Salary = Salary;
        //    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
        //}

        //----------3.3----------
        //public ActionResult SaveEmployee([ModelBinder(typeof(MyEmployeeModelBinder))]Employee e, string BtnSubmit)
        //{
        //    switch (BtnSubmit)
        //    {
        //        case "Save Employee":
        //            return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
        //        case "Cancel":
        //            return RedirectToAction("Index", "Employee");
        //    }
        //    return new EmptyResult();
        //}

        //public ActionResult SaveEmployee()
        //{
        //    Employee e = new Employee();
        //    UpdateModel<Employee>(e);
        //}

        public ActionResult CancelSave(Employee e)
        {
            return RedirectToAction("Index", "Employee");
        }

        [Authorize]
        [HeaderFooterFilter]
        //[Route("Employee/List/{id:int}")]
        public ActionResult GetEmployeeById(int pEmpId)
        {
            Employee employee = new EmployeeBusinessLayer().GetEmployeeById(pEmpId);
            ViewEmployeeViewModel employeeViewModel = new ViewEmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.FirstName + " " + employee.LastName,
                Salary = employee.Salary.Value.ToString("C")
            };

            return View("ViewEmployee", employeeViewModel);
        }
    }
}
