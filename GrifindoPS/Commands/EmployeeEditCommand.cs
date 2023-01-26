using GrifindoPS.Models;
using GrifindoPS.Services;
using GrifindoPS.Services.DataServices;
using GrifindoPS.Stores;
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
        private readonly RuntimeStore _config = RuntimeStore.Instance;
        private readonly NavigationService _empDetailsNavigationService;

        public EmployeeEditCommand(EmployeeListViewModel employeeListViewModel, NavigationService empDetailsNavigationService)
        {
            _employeeListViewModel = employeeListViewModel;
            _empDetailsNavigationService = empDetailsNavigationService;

            employeeListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_employeeListViewModel.SelectedEmployee != null) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_employeeListViewModel != null && _employeeListViewModel.SelectedEmployee != null)
            {
                _config.CurrentEmployee = _employeeListViewModel.SelectedEmployee;
                _empDetailsNavigationService.Navigate();
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_employeeListViewModel.SelectedEmployee))
            {
                RaiseCanExecuteChanged();
            }
        }
    }
}
