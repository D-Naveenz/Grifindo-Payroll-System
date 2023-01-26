using GrifindoPS.Commands;
using GrifindoPS.DBContexts;
using GrifindoPS.Models;
using GrifindoPS.Services;
using GrifindoPS.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GrifindoPS.ViewModels
{
    internal class LeavesListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<LeaveModel> _leaves;
        private readonly GrifindoContextFactory _grifindoDBContextFactory;
        private readonly EmployeeModel? _employee = ConfigStore.Instance.CurrentEmployee;

        private LeaveModel? _selectedLeave;

        public LeavesListViewModel(NavigationService empDetailsNavigationService, NavigationService leavesDetailsNavigationService, NavigationService viewModelRefreshService,
            GrifindoContextFactory grifindoDBContextFactory)
        {
            _leaves = new ObservableCollection<LeaveModel>();
            _grifindoDBContextFactory = grifindoDBContextFactory;
            if (_employee != null)
            {
                UpdateLeaves();
            }

            AddCommand = new NavigationCommand(leavesDetailsNavigationService);
            EditCommand = new LeaveEditCommand(this, leavesDetailsNavigationService);
            DeleteCommand = new LeaveDeleteCommand(this, viewModelRefreshService);
            BackCommand = new NavigationCommand(empDetailsNavigationService);
        }

        private void UpdateLeaves()
        {
            _leaves.Clear();
            using GrifindoContext _dbContext = _grifindoDBContextFactory.CreateDbContext();
            if (_employee != null)
            {
                foreach (LeaveModel leave in _dbContext.Leave)
                {
                    if (leave.EmpId == _employee.Id)
                    {
                        _leaves.Add(leave);
                    }
                }
            }
        }

        public IEnumerable<LeaveModel> Leaves => _leaves;

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }
        
        public ICommand BackCommand { get; }

        public LeaveModel? SelectedLeave
        {
            get { return _selectedLeave; }
            set
            {
                _selectedLeave = value;
                OnPropertyChanged(nameof(SelectedLeave));
            }
        }
    }
}