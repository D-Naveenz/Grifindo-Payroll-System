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

        public IDataService<Employee>? EmployeeDataService { get; set; }
        public Employee CurrentEmployee { get; set; }
        public IDataService<Leave>? LeaveDataService { get; set; }
        public Leave CurrentLeave { get; set; }
    }
}
