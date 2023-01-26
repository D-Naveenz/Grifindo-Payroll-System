using GrifindoPS.Models;
using GrifindoPS.Services.DataServices;
using GrifindoPS.Stores;
using GrifindoPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrifindoPS.Commands
{
    class LoadLeavesCommand : AsyncCommndBase
    {
        private readonly LeavesListViewModel _leaveListViewModel;
        private readonly EmployeeDataService _employeeDataService = ConfigStore.Instance.EmployeeDataService;

        public LoadLeavesCommand(LeavesListViewModel leaveListViewModel)
        {
            _leaveListViewModel = leaveListViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                IEnumerable<LeaveModel> leaves = await _employeeDataService.GetAllLeaves(ConfigStore.Instance.CurrentEmployee);
                _leaveListViewModel.UpdateLeaves(leaves);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The Employee leaves list loading failed!\n" + ex, "GrifindoPS: Error - Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
