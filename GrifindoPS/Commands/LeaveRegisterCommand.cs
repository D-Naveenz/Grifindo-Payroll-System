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
            throw new NotImplementedException();
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
