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
using GrifindoPS.Stores;
using GrifindoPS.Services.DataServices;

namespace GrifindoPS.Commands
{
    internal class EmployeeRegisterCommand : CommandBase
    {
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;
        private readonly IDataService<Employee>? _employeeDataService;
        private readonly NavigationService _empListNavigationService;

        public EmployeeRegisterCommand(EmployeeDetailsViewModel employeeDetailsViewModel, NavigationService empListNavigationService)
        {
            _employeeDetailsViewModel = employeeDetailsViewModel;
            _employeeDataService = ConfigStore.Instance.EmployeeDataService;
            _empListNavigationService = empListNavigationService;

            employeeDetailsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_employeeDetailsViewModel.Name) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Employee employee = new(
                _employeeDetailsViewModel.Name,
                _employeeDetailsViewModel.Role,
                _employeeDetailsViewModel.BOD.Date,
                _employeeDetailsViewModel.Gender,
                _employeeDetailsViewModel.Address,
                _employeeDetailsViewModel.Phone,
                _employeeDetailsViewModel.Email,
                _employeeDetailsViewModel.MonthlySalary,
                _employeeDetailsViewModel.OtRate,
                _employeeDetailsViewModel.Allowance
                );

            try
            {
                if (_employeeDataService != null)
                {
                    _employeeDataService.Add(employee);
                    ConfigStore.Instance.CurrentEmployee = employee;

                    MessageBox.Show("The Employee is successfully registered.", "GrifindoPS: Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _empListNavigationService.Navigate();
                }
            }
            catch (RecordAlreadyExistingException)
            {
                MessageBox.Show("The Employee is already existing.", "GrifindoPS: Error - Resource Conflict", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_employeeDetailsViewModel.Name))
            {
                RaiseCanExecuteChanged();
            }
        }
    }
}
