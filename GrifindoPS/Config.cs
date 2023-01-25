using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrifindoPS.Models;
using GrifindoPS.Exceptions;

namespace GrifindoPS
{
    public class Config
    {
        private static readonly Config _instance = new();
        private readonly List<Employee> _employees;
        private DateTime _cycleBegin;
        private DateTime _cycleEnd;

        private Config()
        {
            _employees = new();

            // For Debugging
            _cycleBegin = new(2023, 1, 1);
            _cycleEnd = new(2023, 1, 31);
        }

        public static Config Instance => _instance;

        public DateTime CycleBegin
        {
            get => _cycleBegin;
            set
            {
                if (value > _cycleEnd)
                {
                    throw new InvalidCycleException(value, _cycleEnd);
                }

                _cycleBegin = value;
            }
        }

        public DateTime CycleEnd
        {
            get => _cycleEnd;
            set
            {
                if (value < _cycleBegin)
                {
                    throw new InvalidCycleException(_cycleBegin, value);
                }

                _cycleEnd = value;
            }
        }

        public TimeSpan CycleRange()
        {
            return _cycleEnd.Subtract(_cycleBegin);
        }

        public float GvtTax { get; set; }

        public IEnumerable<Employee> Employees => _employees;

        public Employee? CurrentEmployee { get; set; }
        public Leave? CurrentLeave { get; set; }

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
