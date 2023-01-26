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
    internal class LeaveUpdateCommand : CommandBase
    {
        private readonly Config _config;
        private readonly LeavesDetailsViewModel _leavesDetailsViewModel;
        private readonly NavigationService _leavesListNavigationService;

        public LeaveUpdateCommand(LeavesDetailsViewModel leavesDetailsViewModel, NavigationService leavesListNavigationService)
        {
            _config = Config.Instance;
            _leavesDetailsViewModel = leavesDetailsViewModel;
            _leavesListNavigationService = leavesListNavigationService;
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
