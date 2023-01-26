using GrifindoPS.Commands;
using GrifindoPS.DBContexts;
using GrifindoPS.Models;
using GrifindoPS.Services;
using GrifindoPS.Services.DataServices;
using GrifindoPS.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GrifindoPS.ViewModels
{
    internal class EmployeeListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<EmployeeModel> _employees;
        private EmployeeModel? _selectedEmployee;
        
        public EmployeeListViewModel(NavigationService empDetailsNavigationService, NavigationService settingsNavigationService, NavigationService viewModelRefreshService)
        {

            _employees = new ObservableCollection<EmployeeModel>();

            RuntimeStore.Instance.CurrentEmployee = null;

            LoadEmployeesCommand = new LoadEmployeesCommand(this);
            AddCommand = new NavigationCommand(empDetailsNavigationService);
            EditCommand = new EmployeeEditCommand(this, empDetailsNavigationService);
            DeleteCommand = new EmployeeDeleteCommand(this, viewModelRefreshService);
            SettingsCommand = new NavigationCommand(settingsNavigationService);
        }

        public static EmployeeListViewModel LoadViewModel(NavigationService empDetailsNavigationService, NavigationService settingsNavigationService, NavigationService viewModelRefreshService)
        {
            EmployeeListViewModel viewModel = new EmployeeListViewModel(empDetailsNavigationService, settingsNavigationService, viewModelRefreshService);
            viewModel.LoadEmployeesCommand.Execute(null);
            return viewModel;
        }

        public void UpdateEmployees(IEnumerable<EmployeeModel> employees)
        {
            _employees.Clear();
            foreach (EmployeeModel employee in employees)
            {
                _employees.Add(employee);
            }
        }

        public IEnumerable<EmployeeModel> Employees => _employees;

        public ICommand LoadEmployeesCommand { get; }

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }

        public ICommand SettingsCommand { get; }

        public EmployeeModel? SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(SelectedEmployee));
            }
        }
    }
}
