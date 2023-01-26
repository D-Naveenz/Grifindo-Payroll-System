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
    internal class LeaveUpdateCommand : CommandBase
    {
        private readonly IDataService<LeaveModel> _leaveDataService = ConfigStore.Instance.LeaveDataService;
        private readonly LeavesDetailsViewModel _leavesDetailsViewModel;
        private readonly NavigationService _leavesListNavigationService;

        public LeaveUpdateCommand(LeavesDetailsViewModel leavesDetailsViewModel, NavigationService leavesListNavigationService)
        {
            _leavesDetailsViewModel = leavesDetailsViewModel;
            _leavesListNavigationService = leavesListNavigationService;
        }

        public override void Execute(object? parameter)
        {
            LeaveModel leave = new(
                _leavesDetailsViewModel.Id,
                _leavesDetailsViewModel.Date,
                _leavesDetailsViewModel.Description,
                ConfigStore.Instance.CurrentEmployee,
                _leavesDetailsViewModel.Approval
                );

            try
            {
                _leaveDataService.Update(leave);

                MessageBox.Show("The leave is successfully updated.", "GrifindoPS: Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _leavesListNavigationService.Navigate();
            }
            catch (RecordAlreadyExistingException ex)
            {
                MessageBox.Show("Update Leave operation failed!\n" + ex, "GrifindoPS: Error - Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
