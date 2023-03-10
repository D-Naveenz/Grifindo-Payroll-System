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
    internal class EmployeeRegisterCommand : AsyncCommndBase
    {
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;
        private readonly IDataService<EmployeeModel> _employeeDataService;
        private readonly NavigationService _empListNavigationService;

        public EmployeeRegisterCommand(EmployeeDetailsViewModel employeeDetailsViewModel, NavigationService empListNavigationService)
        {
            _employeeDetailsViewModel = employeeDetailsViewModel;
            _employeeDataService = RuntimeStore.Instance.EmployeeDataService;
            _empListNavigationService = empListNavigationService;

            employeeDetailsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_employeeDetailsViewModel.Name) && 
                !string.IsNullOrEmpty(_employeeDetailsViewModel.Email) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            EmployeeModel employee = new(
                Guid.NewGuid(),
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
                await _employeeDataService.Add(employee);

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
            if (e.PropertyName == nameof(_employeeDetailsViewModel.Name) ||
                e.PropertyName == nameof(_employeeDetailsViewModel.Email))
            {
                RaiseCanExecuteChanged();
            }
        }
    }
}
