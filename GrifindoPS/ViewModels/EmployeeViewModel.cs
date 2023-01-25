using GrifindoPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.ViewModels
{
    internal class EmployeeViewModel : ViewModelBase
    {
        private readonly Employee _employee;

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }

        public string Id => _employee.Id;
        public string Name => _employee.Name;
        public string Role => _employee.Role;
        public string Gender => _employee.Gender.ToString();
        public string PhoneNo => _employee.PhoneNo?.ToString() ?? "N/A";
        public string Email => _employee.Email?.ToString() ?? "N/A";
    }
}
