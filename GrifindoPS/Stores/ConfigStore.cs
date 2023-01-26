using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrifindoPS.Stores
{
    internal class ConfigStore
    {
        public ConfigStore(string connectionString, DateTime cycleBegin, DateTime cycleEnd, float gvtTax)
        {
            ConnectionString = connectionString;
            CycleBegin = cycleBegin;
            CycleEnd = cycleEnd;
            GvtTax = gvtTax;
        }

        public string ConnectionString { get; set; }
        public DateTime CycleBegin { get; set; }
        public DateTime CycleEnd { get; set; }
        public float GvtTax { get; set; }

        public static ConfigStore Load()
        {
            // Read the JSON file and deserialize it into an AppConfiguration object
            string json = File.ReadAllText("config.json");
            return JsonSerializer.Deserialize<ConfigStore>(json);
        }

        public void Save()
        {
            // Serialize the AppConfiguration object into a JSON string
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText("config.json", json);
        }
    }
}
