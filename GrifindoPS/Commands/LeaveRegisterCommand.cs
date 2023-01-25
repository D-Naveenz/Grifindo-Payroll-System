using GrifindoPS.Exceptions;
using GrifindoPS.Models;
using GrifindoPS.Services;
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
        private readonly Config _config;
        private readonly LeavesDetailsViewModel _leavesDetailsViewModel;
        private readonly NavigationService _leavesListNavigationService;

        public LeaveRegisterCommand(LeavesDetailsViewModel leavesDetailsViewModel, NavigationService leavesListNavigationService)
        {
            _config = Config.Instance;
            _leavesDetailsViewModel = leavesDetailsViewModel;
            _leavesListNavigationService = leavesListNavigationService;

            leavesDetailsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _leavesDetailsViewModel.Approval != string.Empty && (_leavesDetailsViewModel.Date != new DateTime(2000, 1, 1)) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            if (_config.CurrentEmployee != null)
            {
                try
                {
                    _config.CurrentEmployee.AddLeave(
                        new(
                            _config.CurrentEmployee,
                            _leavesDetailsViewModel.Date.Date,
                            _leavesDetailsViewModel.Description,
                            _leavesDetailsViewModel.Approval
                            )
                        );

                    MessageBox.Show("The leave is successfully added.", "GrifindoPS: Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    _leavesListNavigationService.Navigate();
                }
                catch (RecordAlreadyExistingException)
                {
                    MessageBox.Show("The leave data is already existing.", "GrifindoPS: Error - Resource Conflict", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
