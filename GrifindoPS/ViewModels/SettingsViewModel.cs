using GrifindoPS.Commands;
using GrifindoPS.Services;
using GrifindoPS.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GrifindoPS.ViewModels
{
    internal class SettingsViewModel : ViewModelBase
    {
        private ConfigStore _configStore = RuntimeStore.Instance.ConfigStore;

        public SettingsViewModel(NavigationService empListNavigationService)
        {
            SaveCommand = new SettingsSaveCommand(empListNavigationService);
            BackCommand = new NavigationCommand(empListNavigationService);
        }

        public DateTime CycleBegin
        {
            get
            {
                return _configStore.CycleBegin;
            }

            set
            {
                _configStore.CycleBegin = value.Date;
                OnPropertyChanged(nameof(CycleBegin));
            }
        }

        public DateTime CycleEnd
        {
            get => _configStore.CycleEnd;
            set
            {
                _configStore.CycleEnd = value.Date;
                OnPropertyChanged(nameof(CycleEnd));
            }
        }

        public float GvtTax
        {
            get => _configStore.GvtTax;
            set
            {
                _configStore.GvtTax = value;
                OnPropertyChanged(nameof(GvtTax));
            }
        }
        
        public ICommand BackCommand { get; }
        public ICommand SaveCommand { get; }
    }
}
