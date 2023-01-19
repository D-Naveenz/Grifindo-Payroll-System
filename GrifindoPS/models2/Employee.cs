using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.models
{
    internal class Employee
    {
        public string? EmpId { get; set; }
        public string? EmpName { get; set; }
        public string? TitleID { get; set; }
        public string? Title { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }

    }
}
