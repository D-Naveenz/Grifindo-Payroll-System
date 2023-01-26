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
        private readonly ObservableCollection<Leave> _leaves;
        private readonly GrifindoDBContextFactory _grifindoDBContextFactory;
        private readonly Employee? _employee = Config.Instance.CurrentEmployee;

        private Leave? _selectedLeave;

        public LeavesListViewModel(NavigationService empDetailsNavigationService, NavigationService leavesDetailsNavigationService, NavigationService viewModelRefreshService,
            GrifindoDBContextFactory grifindoDBContextFactory)
        {
            _leaves = new ObservableCollection<Leave>();
            if (_employee != null)
            {
                UpdateLeaves();
            }
            _grifindoDBContextFactory = grifindoDBContextFactory;

            AddCommand = new NavigationCommand(leavesDetailsNavigationService);
            EditCommand = new LeaveEditCommand(this, leavesDetailsNavigationService);
            DeleteCommand = new LeaveDeleteCommand(this, viewModelRefreshService);
            BackCommand = new NavigationCommand(empDetailsNavigationService);
        }

        private void UpdateLeaves()
        {
            _leaves.Clear();
            using GrifindoDBContext _dbContext = _grifindoDBContextFactory.CreateDbContext();
            if (_employee != null)
            {
                foreach (Leave leave in _dbContext.Leaves)
                {
                    if (leave.EmployeeId == _employee.Id)
                    {
                        _leaves.Add(leave);
                    }
                }
            }
        }

        public IEnumerable<Leave> Leaves => _leaves;

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }
        
        public ICommand BackCommand { get; }

        public Leave? SelectedLeave
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