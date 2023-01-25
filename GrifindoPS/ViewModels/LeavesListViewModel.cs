using GrifindoPS.Commands;
using GrifindoPS.Models;
using GrifindoPS.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GrifindoPS.ViewModels
{
    internal class LeavesListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<Leave> _leaves;
        private readonly Employee? _employee;

        private Leave? _selectedLeave;

        public LeavesListViewModel(NavigationService empDetailsNavigationService, NavigationService leavesDetailsNavigationService, NavigationService viewModelRefreshService)
        {
            _employee = Config.Instance.CurrentEmployee;
            
            if (_employee != null)
            {
                _leaves = new ObservableCollection<Leave>(_employee.GellAllLeaves());
            }
            else
            {
                _leaves = new ObservableCollection<Leave>();
            }

            AddCommand = new NavigationCommand(leavesDetailsNavigationService);
            EditCommand = new LeaveEditCommand(this, leavesDetailsNavigationService);
            DeleteCommand = new LeaveDeleteCommand(this, viewModelRefreshService);
            BackCommand = new NavigationCommand(empDetailsNavigationService);
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