using GrifindoPS.DBContexts;
using GrifindoPS.Models;
using GrifindoPS.Services.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Stores
{
    internal class ConfigStore
    {
        private static readonly ConfigStore _instance = new();

        public static ConfigStore Instance => _instance;

        public IDataService<EmployeeModel> EmployeeDataService { get; set; }
        public EmployeeModel CurrentEmployee { get; set; }
        public IDataService<LeaveModel> LeaveDataService { get; set; }
        public LeaveModel CurrentLeave { get; set; }
    }
}
