using GrifindoPS.Exceptions;
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
    internal class LeaveRegisterCommand : CommandBase
    {
        private readonly LeavesDetailsViewModel _leavesDetailsViewModel;
        private readonly NavigationService _leavesListNavigationService;
        private readonly IDataService<LeaveModel> _leaveDataService;

        public LeaveRegisterCommand(LeavesDetailsViewModel leavesDetailsViewModel, NavigationService leavesListNavigationService)
        {
            _leavesDetailsViewModel = leavesDetailsViewModel;
            _leavesListNavigationService = leavesListNavigationService;
            _leaveDataService = ConfigStore.Instance.LeaveDataService;

            leavesDetailsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _leavesDetailsViewModel.Approval != string.Empty && (_leavesDetailsViewModel.Date != new DateTime(2000, 1, 1)) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            LeaveModel leave = new()
            {
                Id = Guid.NewGuid(),
                Date = _leavesDetailsViewModel.Date,
                Description = _leavesDetailsViewModel.Description,
                Approval = _leavesDetailsViewModel.Approval,
                EmpId = ConfigStore.Instance.CurrentEmployee.Id,
                Emp = ConfigStore.Instance.CurrentEmployee
            };

            try
            {
                if (_leaveDataService != null)
                {
                    _leaveDataService.Add(leave);
                    ConfigStore.Instance.CurrentLeave = leave;

                    MessageBox.Show("The leave is successfully registered.", "GrifindoPS: Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _leavesListNavigationService.Navigate();
                }
            }
            catch (RecordAlreadyExistingException)
            {
                MessageBox.Show("The leave is already existing.", "GrifindoPS: Error - Resource Conflict", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_leavesDetailsViewModel.Approval))
            {
                RaiseCanExecuteChanged();
            }
        }
    }
}
