using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Security.RightsManagement;

namespace GrifindoPS.config
{
    [Serializable]
    internal class Config
    {
        const string json_file = @"config\config.json";

        public DB db_config = new()
        {
            // Development server configs
            data_source = "localhost",
            initial_catalog = "Grifindo",
            integrated_sec = true
        };
    }
}
