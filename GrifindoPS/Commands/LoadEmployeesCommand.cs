using GrifindoPS.Models;
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
    internal class LoadEmployeesCommand : AsyncCommndBase
    {
        private readonly EmployeeListViewModel _employeeListViewModel;
        private readonly IDataService<EmployeeModel> _employeeDataService = RuntimeStore.Instance.EmployeeDataService;

        public LoadEmployeesCommand(EmployeeListViewModel employeeListViewModel)
        {
            _employeeListViewModel = employeeListViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                IEnumerable<EmployeeModel> employees = await _employeeDataService.GetAll();
                _employeeListViewModel.UpdateEmployees(employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Employee list loading failed!\n" + ex, "GrifindoPS: Error - Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
