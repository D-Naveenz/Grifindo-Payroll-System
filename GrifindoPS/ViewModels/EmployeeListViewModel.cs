using GrifindoPS.Commands;
using GrifindoPS.Data.Models;
using GrifindoPS.Services;
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
        private readonly ObservableCollection<EmployeeViewModel> _employees;
        private readonly Config _config;

        private EmployeeViewModel? _selectedEmployeeViewModel;
        
        public EmployeeListViewModel(NavigationService empDetailsNavigationService, NavigationService viewModelRefreshService)
        {
            _config = Config.Instance;
            _employees = new ObservableCollection<EmployeeViewModel>();

            _config.CurrentEmployee = null;
            UpdateEmployees();

            AddCommand = new NavigationCommand(empDetailsNavigationService);
            EditCommand = new EmployeeEditCommand(this, empDetailsNavigationService);
            DeleteCommand = new EmployeeDeleteCommand(this, viewModelRefreshService);
        }

        private void UpdateEmployees()
        {
            _employees.Clear();
            foreach (var employee in _config.Employees)
            {
                _employees.Add(new EmployeeViewModel(employee));
            }
        }

        internal void RefreshList()
        {
            OnPropertyChanged(nameof(Employees));
        }

        public IEnumerable<EmployeeViewModel> Employees => _employees;

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }

        public EmployeeViewModel? SelectedEmployeeViewModel
        {
            get { return _selectedEmployeeViewModel; }
            set
            {
                _selectedEmployeeViewModel = value;
                OnPropertyChanged(nameof(SelectedEmployeeViewModel));
            }
        }
    }
}
