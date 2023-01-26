using GrifindoPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Exceptions
{
    internal class RecordAlreadyExistingException : Exception
    {
        public EmployeeModel ExistingEmployee { get; }
        public EmployeeModel NewEmployee { get; }


        public RecordAlreadyExistingException(EmployeeModel existingEmployee, EmployeeModel newEmployee)
        {
            ExistingEmployee = existingEmployee;
            NewEmployee = newEmployee;
        }

        public RecordAlreadyExistingException(string? message, EmployeeModel existingEmployee, EmployeeModel newEmployee) : base(message)
        {
            ExistingEmployee = existingEmployee;
            NewEmployee = newEmployee;
        }

        public RecordAlreadyExistingException(string? message, Exception? innerException, EmployeeModel existingEmployee, EmployeeModel newEmployee) : base(message, innerException)
        {
            ExistingEmployee = existingEmployee;
            NewEmployee = newEmployee;
        }
    }
}
