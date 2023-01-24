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
            OtRate = 0;
            Allowance = 0;
        }

        public Salary(float monthlySalary, float otRate, float allowance)
        {
            MonthlySalary = monthlySalary;
            OtRate = otRate;
            Allowance = allowance;
        }

        public float MonthlySalary { get; set; }
        public float OtRate { get; set; }
        public float Allowance { get; set; }
    }
}
