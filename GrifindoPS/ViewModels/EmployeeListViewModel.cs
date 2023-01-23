using GrifindoPS.Commands;
using GrifindoPS.Data.Models;
using GrifindoPS.Services;
using GrifindoPS.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GrifindoPS.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
    {
        private readonly Employee _employee;

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }

        public string Id => _employee.Id;
        public string Name => _employee.Name;
        public string Role => _employee.Role.Title;
        public string Gender => _employee.Gender.ToString();
        public string PhoneNo => _employee.PhoneNo?.ToString() ?? "N/A";
        public string Email => _employee.Email?.ToString() ?? "N/A";
    }

    public class EmployeeListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<EmployeeViewModel> _employees;
        public EmployeeListViewModel(NavigationService empListNavigationService)
        {
            _employees = new ObservableCollection<EmployeeViewModel>
            {
                // For Debugging
                new EmployeeViewModel(new Employee("0001", "Naveen", new Role("Admin", true, true, true), DateTime.Now, Gender.Male)),
                new EmployeeViewModel(new Employee("0002", "Sunil", new Role("User", false, false, false), DateTime.Now, Gender.Female))
            };
            
            AddCommand = new NavigationCommand(empListNavigationService);
            EditCommand = new EditEmployeeCommand();
            DeleteCommand = new DeleteEmployeeCommand();
        }

        public IEnumerable<EmployeeViewModel> Employees => _employees;

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }
    }
}
