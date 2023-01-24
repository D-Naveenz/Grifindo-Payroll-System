using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrifindoPS.Data.Models;
using GrifindoPS.Exceptions;

namespace GrifindoPS
{
    public class Config
    {
        private static readonly Config _instance = new();
        private readonly List<Employee> _employees;

        private Config()
        {
            _employees = new();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employees;
        }

        public IEnumerable<Employee> Employees => _employees;

        public static Config Instance => _instance;

        public Employee? CurrentEmployee { get; set; }

        public void AddEmployee(Employee employee)
        {
            foreach (Employee emp in _employees)
            {
                if (emp.Id == employee.Id)
                {
                    throw new RecordAlreadyExistingException(emp, employee);
                }
            }

            _employees.Add(employee);
        }

        public void RemoveEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            var emp = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (emp != null)
            {
                emp.Name = employee.Name;
                emp.Role = employee.Role;
                emp.BOD = employee.BOD;
            }
        }
    }
}
