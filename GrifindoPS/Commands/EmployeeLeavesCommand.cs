using GrifindoPS.Services;
using GrifindoPS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Commands
{
    internal class EmployeeLeavesCommand : CommandBase
    {
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;
        private readonly NavigationService _empLeavesNavigationService;

        public EmployeeLeavesCommand(EmployeeDetailsViewModel employeeDetailsViewModel, NavigationService empLeavesNavigationService)
        {
            _employeeDetailsViewModel = employeeDetailsViewModel;
            _empLeavesNavigationService = empLeavesNavigationService;

            employeeDetailsViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object? parameter)
        {
            return _employeeDetailsViewModel.SubmitName == "Update";
        }
        
        public override void Execute(object? parameter)
        {
            _empLeavesNavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_employeeDetailsViewModel.SubmitName))
            {
                RaiseCanExecuteChanged();
            }
        }
    }
}
