using GrifindoPS.Models;
using GrifindoPS.Services;
using GrifindoPS.Services.DataServices;
using GrifindoPS.Stores;
using GrifindoPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrifindoPS.Commands
{
    internal class EmployeeUpdateCommand : CommandBase
    {
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;
        private readonly IDataService<EmployeeModel>? _employeeDataContext;
        private readonly NavigationService _empListNavigationService;

        public EmployeeUpdateCommand(EmployeeDetailsViewModel employeeDetailsViewModel, NavigationService empListNavigationService)
        {
            _employeeDetailsViewModel = employeeDetailsViewModel;
            _empListNavigationService = empListNavigationService;
            _employeeDataContext = ConfigStore.Instance.EmployeeDataService;
        }

        public override void Execute(object? parameter)
        {
            if (_employeeDataContext == null)
                return;

            EmployeeModel? _employee = ConfigStore.Instance.CurrentEmployee;

            if (_employee == null)
                return;

            _employee.Name = _employeeDetailsViewModel.Name;
            _employee.Role = _employeeDetailsViewModel.Role;
            _employee.Birthday = _employeeDetailsViewModel.BOD;
            _employee.Gender = _employeeDetailsViewModel.Gender;
            _employee.Address = _employeeDetailsViewModel.Address;
            _employee.PhoneNo = _employeeDetailsViewModel.Phone;
            _employee.Email = _employeeDetailsViewModel.Email;
            _employee.MonthlySalary = _employeeDetailsViewModel.MonthlySalary;
            _employee.OtRate = _employeeDetailsViewModel.OtRate;
            _employee.Allowance = _employeeDetailsViewModel.Allowance;

            _employeeDataContext.Update(_employee);

            MessageBox.Show("Employee details successfully updated.", "GrifindoPS: Success", MessageBoxButton.OK, MessageBoxImage.Information);
            _empListNavigationService.Navigate();
        }
    }
}
