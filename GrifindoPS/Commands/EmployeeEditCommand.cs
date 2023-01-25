using GrifindoPS.Models;
using GrifindoPS.Services;
using GrifindoPS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Commands
{
    internal class EmployeeEditCommand : CommandBase
    {
        private readonly EmployeeListViewModel _employeeListViewModel;
        private readonly Config _config;
        private readonly NavigationService _empDetailsNavigationService;

        public EmployeeEditCommand(EmployeeListViewModel employeeListViewModel, NavigationService empDetailsNavigationService)
        {
            _employeeListViewModel = employeeListViewModel;
            _config = Config.Instance;
            _empDetailsNavigationService = empDetailsNavigationService;

            employeeListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_employeeListViewModel.SelectedEmployeeViewModel != null) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_employeeListViewModel.SelectedEmployeeViewModel != null)
            {
                _config.CurrentEmployee = _config.Employees.Where(e => e.Id == _employeeListViewModel.SelectedEmployeeViewModel.Id).First();
                _empDetailsNavigationService.Navigate();
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_employeeListViewModel.SelectedEmployeeViewModel))
            {
                RaiseCanExecuteChanged();
            }
        }
    }
}
