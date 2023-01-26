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
        private readonly ConfigStore _config = ConfigStore.Instance;
        private readonly NavigationService _empDetailsNavigationService;
        private readonly IDataService<EmployeeModel> _employeeDataService;

        public EmployeeEditCommand(EmployeeListViewModel employeeListViewModel, NavigationService empDetailsNavigationService)
        {
            _employeeListViewModel = employeeListViewModel;
            _empDetailsNavigationService = empDetailsNavigationService;
            _employeeDataService = _config.EmployeeDataService;

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
