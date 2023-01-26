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
        private readonly ObservableCollection<EmployeeModel> _employees;
        private readonly ConfigStore _config = ConfigStore.Instance;
        private readonly GrifindoContextFactory _grifindoDBContextFactory;
        private EmployeeModel? _selectedEmployee;
        
        public EmployeeListViewModel(NavigationService empDetailsNavigationService, NavigationService viewModelRefreshService, GrifindoContextFactory grifindoDBContextFactory)
        {

            _employees = new ObservableCollection<EmployeeModel>();
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
            using GrifindoContext _dbContext = _grifindoDBContextFactory.CreateDbContext();
            foreach (EmployeeModel employee in _dbContext.Employee)
            {
                _employees.Add(employee);
            }
        }

        public IEnumerable<EmployeeModel> Employees => _employees;

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }

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
