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
using System.Windows;

namespace GrifindoPS.Commands
{
    internal class EmployeeDeleteCommand : AsyncCommndBase
    {
        private readonly EmployeeListViewModel _employeeListViewModel;
        private readonly NavigationService _viewModelRefreshService;
        private readonly IDataService<EmployeeModel> _employeeDataService;
        
        public EmployeeDeleteCommand(EmployeeListViewModel employeeListViewModel, NavigationService viewModelRefreshService)
        {
            _employeeListViewModel = employeeListViewModel;
            _viewModelRefreshService = viewModelRefreshService;
            _employeeDataService = ConfigStore.Instance.EmployeeDataService;

            employeeListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return (_employeeListViewModel.SelectedEmployee != null) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                if (_employeeListViewModel.SelectedEmployee == null) throw new Exception("Couldn't locate Employee data!");

                EmployeeModel selected = _employeeListViewModel.SelectedEmployee;
                await _employeeDataService.Delete(selected);
                MessageBox.Show("The Employee is successfully deleted.", "GrifindoPS: Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _viewModelRefreshService.Navigate();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Delete Employee operation failed!\n" + ex, "GrifindoPS: Error - Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
