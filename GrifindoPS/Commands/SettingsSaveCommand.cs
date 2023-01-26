using GrifindoPS.Services;
using GrifindoPS.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Commands
{
    internal class SettingsSaveCommand : CommandBase
    {
        private NavigationService empListNavigationService;

        public SettingsSaveCommand(NavigationService empListNavigationService)
        {
            this.empListNavigationService = empListNavigationService;
        }

        public override void Execute(object? parameter)
        {
            RuntimeStore.Instance.ConfigStore.Save();
            empListNavigationService.Navigate();
        }
    }
}
