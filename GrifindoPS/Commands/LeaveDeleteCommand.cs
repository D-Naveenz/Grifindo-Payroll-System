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
using System.Windows;

namespace GrifindoPS.Commands
{
    internal class LeaveDeleteCommand : AsyncCommndBase
    {
        private readonly LeavesListViewModel _leavesListViewModel;
        private readonly NavigationService _viewModelRefreshService;
        private readonly IDataService<LeaveModel> _leaveDataService = ConfigStore.Instance.LeaveDataService;

        public LeaveDeleteCommand(LeavesListViewModel leavesListViewModell, NavigationService viewModelRefreshService)
        {
            _leavesListViewModel = leavesListViewModell;
            _viewModelRefreshService = viewModelRefreshService;

            leavesListViewModell.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _leavesListViewModel.SelectedLeave != null && base.CanExecute(parameter);
        }

        public override async void Execute(object? parameter)
        {
            try
            {
                if (_leavesListViewModel.SelectedLeave == null) throw new Exception("Couldn't locate Leave data!");

                LeaveModel leave = _leavesListViewModel.SelectedLeave;
                await _leaveDataService.Delete(leave);
                MessageBox.Show("The Leave is successfully deleted.", "GrifindoPS: Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _viewModelRefreshService.Navigate();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Delete Leave operation failed!\n" + ex, "GrifindoPS: Error - Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override Task ExecuteAsync(object? parameter)
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
