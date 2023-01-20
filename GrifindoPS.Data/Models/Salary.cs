using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Data.Models
{
    public class Salary
    {
        public Salary()
        {
            MonthlySalary = 0;
        }

        public float MonthlySalary { get; set; }
        public float? OtRate { get; set; }
        public float? Allowance { get; set; }
    }
}
