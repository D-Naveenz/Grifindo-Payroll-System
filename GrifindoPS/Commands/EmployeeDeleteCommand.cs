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
    internal class EmployeeDeleteCommand : CommandBase
    {
        private readonly EmployeeListViewModel _employeeListViewModel;
        private readonly ConfigStore _config = ConfigStore.Instance;
        private readonly NavigationService _viewModelRefreshService;
        private readonly IDataService<Employee>? _employeeDataService;

        public EmployeeDeleteCommand(EmployeeListViewModel employeeListViewModel, NavigationService viewModelRefreshService)
        {
            _employeeListViewModel = employeeListViewModel;
            _viewModelRefreshService = viewModelRefreshService;
            _employeeDataService = _config.EmployeeDataService;

            employeeListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_employeeListViewModel.SelectedEmployeeViewModel != null) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            
            if (_employeeListViewModel != null && _employeeListViewModel.SelectedEmployeeViewModel != null)
            {
                Employee? selected = _employeeDataService.Get(_employeeListViewModel.SelectedEmployeeViewModel.Id).Result;
                if (selected != null)
                {
                    _employeeDataService.Delete(selected);
                    _viewModelRefreshService.Navigate();
                }
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
