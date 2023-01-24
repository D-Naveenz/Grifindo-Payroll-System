using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Data.Models
{
    public enum Gender
    {
        Male, Female
    }
    
    public class Employee
    {
        private readonly Salary _salary;
        private readonly List<Leave> _leaves;

        public Employee()
        {
            _salary = new();
            _leaves = new();

            Id = "";
            Name = "";
            Role = "";
            BOD = DateTime.Now.Date;
            Gender = "Male";
        }

        public Employee(string id, string name, string role, Salary salary, DateTime bOD, string gender, string? address = null, string? phoneNo = null, string? email = null)
        {
            _salary = salary;
            _leaves = new();
            
            Id = id;
            Name = name;
            Role = role;
            BOD = bOD;
            Gender = gender;
            Address = address;
            PhoneNo = phoneNo;
            Email = email;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime BOD { get; set; }
        public string Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
        public Salary Salary => _salary;

        public IEnumerable<Leave> GellAllLeaves()
        {
            return _leaves.Where(l => l.EmpID == Id);
        }

        public void AddLeave(Leave leave)
        {
            _leaves.Add(leave);
        }

        public void RemoveLeave(Leave leave)
        {
            _leaves.Remove(leave);
        }

        public void UpdateLeave(Leave leave)
        {
            var index = _leaves.FindIndex(l => l.EmpID == leave.EmpID && l.RecordTime == leave.RecordTime);
            _leaves[index] = leave;
        }
    }
}
