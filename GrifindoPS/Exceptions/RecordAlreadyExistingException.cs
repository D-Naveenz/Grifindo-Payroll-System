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
        public Employee ExistingEmployee { get; }
        public Employee NewEmployee { get; }


        public RecordAlreadyExistingException(Employee existingEmployee, Employee newEmployee)
        {
            ExistingEmployee = existingEmployee;
            NewEmployee = newEmployee;
        }

        public RecordAlreadyExistingException(string? message, Employee existingEmployee, Employee newEmployee) : base(message)
        {
            ExistingEmployee = existingEmployee;
            NewEmployee = newEmployee;
        }

        public RecordAlreadyExistingException(string? message, Exception? innerException, Employee existingEmployee, Employee newEmployee) : base(message, innerException)
        {
            ExistingEmployee = existingEmployee;
            NewEmployee = newEmployee;
        }
    }
}
