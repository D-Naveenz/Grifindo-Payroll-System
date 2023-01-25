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

namespace GrifindoPS.Commands
{
    internal class LeaveDeleteCommand : CommandBase
    {
        private readonly ConfigStore _config = ConfigStore.Instance;
        private readonly LeavesListViewModel _leavesListViewModel;
        private readonly NavigationService _viewModelRefreshService;
        private readonly IDataService<Leave>? _leaveDataService;

        public LeaveDeleteCommand(LeavesListViewModel leavesListViewModell, NavigationService viewModelRefreshService)
        {
            _leavesListViewModel = leavesListViewModell;
            _viewModelRefreshService = viewModelRefreshService;
            _leaveDataService = _config.LeaveDataService;

            leavesListViewModell.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _leavesListViewModel.SelectedLeave != null && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_leavesListViewModel.SelectedLeave != null && _leaveDataService != null)
            {
                _leaveDataService.Delete(_leavesListViewModel.SelectedLeave);
                _viewModelRefreshService.Navigate();
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_leavesListViewModel.SelectedLeave))
            {
                RaiseCanExecuteChanged();
            }
        }
    }
}
