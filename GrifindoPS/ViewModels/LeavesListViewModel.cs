using GrifindoPS.Commands;
using GrifindoPS.Data.Models;
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

        public LeavesListViewModel(NavigationService empDetailsNavigationService)
        {
            _employee = Config.Instance.CurrentEmployee;
            _leaves = new ObservableCollection<Leave>();
            // For Debugging
            if (_employee != null)
            {
                _leaves.Add(new Leave(_employee, DateTime.Now, "Sick", true));
                _leaves.Add(new Leave(_employee, DateTime.Now, "Party", false));
            }

            AddCommand = new LeaveAddCommand();
            EditCommand = new LeaveAddCommand();
            DeleteCommand = new LeaveAddCommand();
            BackCommand = new NavigationCommand(empDetailsNavigationService);
        }

        public IEnumerable<Leave> Leaves => _leaves;

        public ICommand AddCommand { get; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }
        
        public ICommand BackCommand { get; }
    }
}