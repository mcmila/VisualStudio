using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPISample.Models;

namespace WebAPISample.Controllers
{
    public class EmployeeController : ApiController
    {
        public Employee GET()
        {
            Employee e = new Employee();
            e.FirstName = "Sukesh";
            e.LastName = "Marla";
            e.Salary = 25000;
            return e;
        }
    }
}
