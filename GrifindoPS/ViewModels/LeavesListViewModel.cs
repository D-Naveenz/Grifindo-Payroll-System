using GrifindoPS.Commands;
using GrifindoPS.DBContexts;
using GrifindoPS.Models;
using GrifindoPS.Services;
using GrifindoPS.Services.DataServices;
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
        private readonly EmployeeModel? _employee = ConfigStore.Instance.CurrentEmployee;
        private readonly EmployeeDataService _employeeDataService = ConfigStore.Instance.EmployeeDataService;

        private LeaveModel? _selectedLeave;

        public LeavesListViewModel(NavigationService empDetailsNavigationService, NavigationService leavesDetailsNavigationService, NavigationService viewModelRefreshService)
        {
            _leaves = new ObservableCollection<LeaveModel>();

            ConfigStore.Instance.CurrentLeave = null;

            LoadLeavesCommand = new LoadLeavesCommand(this);
            AddCommand = new NavigationCommand(leavesDetailsNavigationService);
            EditCommand = new LeaveEditCommand(this, leavesDetailsNavigationService);
            DeleteCommand = new LeaveDeleteCommand(this, viewModelRefreshService);
            BackCommand = new NavigationCommand(empDetailsNavigationService);
        }

        public static LeavesListViewModel LoadViewModel(NavigationService empDetailsNavigationService, NavigationService leavesDetailsNavigationService, NavigationService viewModelRefreshService)
        {
            LeavesListViewModel viewModel = new LeavesListViewModel(empDetailsNavigationService, leavesDetailsNavigationService, viewModelRefreshService);
            viewModel.LoadLeavesCommand.Execute(null);
            return viewModel;
        }

        public void UpdateLeaves(IEnumerable<LeaveModel> leaves)
        {
            _leaves.Clear();
            foreach (LeaveModel leave in leaves)
            {
                _leaves.Add(leave);
            }
        }

        public IEnumerable<LeaveModel> Leaves => _leaves;

        public LoadLeavesCommand LoadLeavesCommand { get; }

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