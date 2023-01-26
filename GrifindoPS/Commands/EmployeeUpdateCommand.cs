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
    internal class EmployeeUpdateCommand : AsyncCommndBase
    {
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;
        private readonly IDataService<EmployeeModel> _employeeDataService = RuntimeStore.Instance.EmployeeDataService;
        private readonly NavigationService _empListNavigationService;

        public EmployeeUpdateCommand(EmployeeDetailsViewModel employeeDetailsViewModel, NavigationService empListNavigationService)
        {
            _employeeDetailsViewModel = employeeDetailsViewModel;
            _empListNavigationService = empListNavigationService;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            EmployeeModel employee = new(
                _employeeDetailsViewModel.Id,
                _employeeDetailsViewModel.Name,
                _employeeDetailsViewModel.Role,
                _employeeDetailsViewModel.Birthday,
                _employeeDetailsViewModel.Gender,
                _employeeDetailsViewModel.Email,
                _employeeDetailsViewModel.MonthlySalary,
                _employeeDetailsViewModel.Allowance,
                _employeeDetailsViewModel.OtRate,
                _employeeDetailsViewModel.OtHours
                );

            try
            {
                await _employeeDataService.Update(employee);

                MessageBox.Show("Employee details successfully updated.", "GrifindoPS: Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _empListNavigationService.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Employee operation failed!\n" + ex, "GrifindoPS: Error - Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
