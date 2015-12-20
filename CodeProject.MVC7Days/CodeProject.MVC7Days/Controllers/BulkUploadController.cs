using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using CodeProject.MVC7Days.BLL;
using CodeProject.MVC7Days.Filters;
using CodeProject.MVC7Days.Models;
using CodeProject.MVC7Days.ViewModels;

namespace CodeProject.MVC7Days.Controllers
{
    public class BulkUploadController : AsyncController
    {
        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

        [AdminFilter]
        //[HandleError] Filtro de Exception Nível Controller
        public async Task<ActionResult> Upload(FileUploadViewModel model)
        {
            int t1 = Thread.CurrentThread.ManagedThreadId;
            List<Employee> employees = await Task.Factory.StartNew<List<Employee>>(() => GetEmployees(model));
            int t2 = Thread.CurrentThread.ManagedThreadId;
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees);
            return RedirectToAction("Index", "Employee");
        }

        private List<Employee> GetEmployees(FileUploadViewModel model)
        {
            List<Employee> employees = new List<Employee>();
            StreamReader csvreader = new StreamReader(model.fileUpload.InputStream);
            csvreader.ReadLine(); // Assuming first line is header
            while (!csvreader.EndOfStream)
            {
                var line = csvreader.ReadLine();
                if (line != null)
                {
                    var values = line.Split(',');//Values are comma separated
                    Employee e = new Employee();
                    e.FirstName = values[0];
                    e.LastName = values[1];
                    e.Salary = int.Parse(values[2]);
                    employees.Add(e);
                }
            }
            return employees;
        }
    }
}