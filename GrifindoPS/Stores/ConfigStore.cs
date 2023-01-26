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
    internal class ConfigStore
    {
        private static bool hasInstance = false;
        private static ConfigStore _instance;
        private GrifindoContextFactory _grifindoContextFactory;
        
        private ConfigStore(GrifindoContextFactory grifindoContextFactory)
        {
            _grifindoContextFactory = grifindoContextFactory;
            EmployeeDataService = new EmployeeDataService(_grifindoContextFactory);
            LeaveDataService = new LeaveDataService(_grifindoContextFactory);
        }

        public static ConfigStore Instance
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

        public static void Initialize(GrifindoContextFactory grifindoContextFactory)
        {
            if (_instance == null)
            {
                _instance = new ConfigStore(grifindoContextFactory);
            }
        }

        public EmployeeDataService EmployeeDataService { get; }
        public EmployeeModel CurrentEmployee { get; set; }
        public LeaveDataService LeaveDataService { get; }
        public LeaveModel CurrentLeave { get; set; }
        
    }
}
