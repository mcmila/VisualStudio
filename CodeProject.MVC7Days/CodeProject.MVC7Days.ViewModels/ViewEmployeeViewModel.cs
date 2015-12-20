using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProject.MVC7Days.ViewModels
{
    public class ViewEmployeeViewModel : BaseViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Salary { get; set; }
        public string SalaryColor { get; set; }
    }
}
