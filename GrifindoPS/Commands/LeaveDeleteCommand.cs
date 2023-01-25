﻿using GrifindoPS.Services;
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
        private readonly Config _config;
        private readonly LeavesListViewModel _leavesListViewModel;
        private readonly NavigationService _viewModelRefreshService;

        public LeaveDeleteCommand(LeavesListViewModel leavesListViewModell, NavigationService viewModelRefreshService)
        {
            _config = Config.Instance;
            _leavesListViewModel = leavesListViewModell;
            _viewModelRefreshService = viewModelRefreshService;

            leavesListViewModell.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _leavesListViewModel.SelectedLeave != null && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_leavesListViewModel.SelectedLeave != null && _config.CurrentEmployee != null)
            {
                _config.CurrentEmployee.RemoveLeave(_leavesListViewModel.SelectedLeave);
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
