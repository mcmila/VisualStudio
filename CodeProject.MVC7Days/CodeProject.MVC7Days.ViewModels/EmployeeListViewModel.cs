using System.Collections.Generic;

namespace CodeProject.MVC7Days.ViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
    }
}