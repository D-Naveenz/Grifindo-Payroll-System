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
    internal class LeaveEditCommand : CommandBase
    {
        private readonly ConfigStore _config = ConfigStore.Instance;
        private readonly LeavesListViewModel _leavesListViewModel;
        private readonly NavigationService _leavesDetailsNavigationService;

        public LeaveEditCommand(LeavesListViewModel leavesListViewModell, NavigationService leavesDetailsNavigationService)
        {
            _leavesListViewModel = leavesListViewModell;
            _leavesDetailsNavigationService = leavesDetailsNavigationService;

            leavesListViewModell.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _leavesListViewModel.SelectedLeave != null && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_leavesListViewModel.SelectedLeave != null)
            {
                _config.CurrentLeave = _leavesListViewModel.SelectedLeave;
                _leavesDetailsNavigationService.Navigate();
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
