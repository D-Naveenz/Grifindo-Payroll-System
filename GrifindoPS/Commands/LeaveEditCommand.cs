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
    internal class LeaveEditCommand : CommandBase
    {
        private readonly Config _config;
        private readonly LeavesListViewModel _leavesListViewModel;
        private readonly NavigationService _leavesDetailsNavigationService;

        public LeaveEditCommand(LeavesListViewModel leavesListViewModell, NavigationService leavesDetailsNavigationService)
        {
            _config = Config.Instance;
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
            throw new NotImplementedException();
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
