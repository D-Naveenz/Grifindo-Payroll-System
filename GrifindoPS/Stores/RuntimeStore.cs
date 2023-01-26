using GrifindoPS.DBContexts;
using GrifindoPS.Models;
using GrifindoPS.Services.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrifindoPS.Stores
{
    internal class RuntimeStore
    {
        private static bool hasInstance = false;
        private static RuntimeStore _instance;
        private GrifindoContextFactory _grifindoContextFactory;

        private RuntimeStore(GrifindoContextFactory grifindoContextFactory, ConfigStore configStore)
        {
            _grifindoContextFactory = grifindoContextFactory;
            EmployeeDataService = new EmployeeDataService(_grifindoContextFactory);
            LeaveDataService = new LeaveDataService(_grifindoContextFactory);
            ConfigStore = configStore;
        }

        public static RuntimeStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new Exception("Config Store is not initialized yet.");
                }
                return _instance;
            }
        }

        public static void Initialize(GrifindoContextFactory grifindoContextFactory, ConfigStore configStore)
        {
            if (_instance == null)
            {
                _instance = new RuntimeStore(grifindoContextFactory, configStore);
            }
        }

        public EmployeeDataService EmployeeDataService { get; }
        public EmployeeModel CurrentEmployee { get; set; }
        public LeaveDataService LeaveDataService { get; }
        public LeaveModel CurrentLeave { get; set; }
        public ConfigStore ConfigStore { get; }

        public TimeSpan CycleRange()
        {
            return ConfigStore.CycleEnd.Subtract(ConfigStore.CycleBegin);
        }
    }
}
