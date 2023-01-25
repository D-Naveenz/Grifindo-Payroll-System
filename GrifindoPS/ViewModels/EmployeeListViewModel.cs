using GrifindoPS.Commands;
using GrifindoPS.DBContexts;
using GrifindoPS.Models;
using GrifindoPS.Services;
using GrifindoPS.Stores;
using Microsoft.EntityFrameworkCore;
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
        private readonly ConfigStore _config = ConfigStore.Instance;
        private readonly GrifindoDBContextFactory _grifindoDBContextFactory;
        private EmployeeViewModel? _selectedEmployeeViewModel;
        
        public EmployeeListViewModel(NavigationService empDetailsNavigationService, NavigationService viewModelRefreshService, GrifindoDBContextFactory grifindoDBContextFactory)
        {

            _employees = new ObservableCollection<EmployeeViewModel>();
            _grifindoDBContextFactory = grifindoDBContextFactory;

            _config.CurrentEmployee = null;
            UpdateEmployees();

            AddCommand = new NavigationCommand(empDetailsNavigationService);
            EditCommand = new EmployeeEditCommand(this, empDetailsNavigationService);
            DeleteCommand = new EmployeeDeleteCommand(this, viewModelRefreshService);
        }

        private void UpdateEmployees()
        {
            _employees.Clear();
            using GrifindoDBContext _dbContext = _grifindoDBContextFactory.CreateDbContext();
            foreach (Employee employee in _dbContext.Employees)
            {
                _employees.Add(new EmployeeViewModel(employee));
            }
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
