using GrifindoPS.Models;
using GrifindoPS.Exceptions;
using GrifindoPS.Services;
using GrifindoPS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrifindoPS.Commands
{
    internal class EmployeeRegisterCommand : CommandBase
    {
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;
        private readonly Config _config;
        private readonly NavigationService _empListNavigationService;

        public EmployeeRegisterCommand(EmployeeDetailsViewModel employeeDetailsViewModel, NavigationService empListNavigationService)
        {
            _employeeDetailsViewModel = employeeDetailsViewModel;
            _config = Config.Instance;
            _empListNavigationService = empListNavigationService;

            employeeDetailsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_employeeDetailsViewModel.Id) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Employee employee = new(
                _employeeDetailsViewModel.Id,
                _employeeDetailsViewModel.Name,
                _employeeDetailsViewModel.Role,
                new(_employeeDetailsViewModel.MonthlySalary, _employeeDetailsViewModel.OtRate, _employeeDetailsViewModel.Allowance),
                _employeeDetailsViewModel.BOD,
                _employeeDetailsViewModel.Gender,
                _employeeDetailsViewModel.Address,
                _employeeDetailsViewModel.Phone,
                _employeeDetailsViewModel.Email
                );
            
            try
            {
                _config.AddEmployee(employee);
                _config.CurrentEmployee = employee;

                MessageBox.Show("The Employee is successfully registered.", "GrifindoPS: Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _empListNavigationService.Navigate();
            }
            catch (RecordAlreadyExistingException)
            {
                MessageBox.Show("The Employee is already existing.", "GrifindoPS: Error - Resource Conflict", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_employeeDetailsViewModel.Id))
            {
                RaiseCanExecuteChanged();
            }
        }
    }
}
