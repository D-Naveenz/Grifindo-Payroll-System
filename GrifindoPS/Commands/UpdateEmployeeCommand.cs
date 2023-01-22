using GrifindoPS.Data.Models;
using GrifindoPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrifindoPS.Commands
{
    public class UpdateEmployeeCommand : CommandBase
    {
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;
        private readonly Employee _employee;

        public UpdateEmployeeCommand(EmployeeDetailsViewModel employeeDetailsViewModel)
        {
            _employeeDetailsViewModel = employeeDetailsViewModel;
            _employee = new();
        }

        public override void Execute(object? parameter)
        {
            _employee.Id = _employeeDetailsViewModel.Id;
            _employee.Name = _employeeDetailsViewModel.Name;
            //_employee.Role = _employeeDetailsViewModel.Role;
            _employee.BOD = _employeeDetailsViewModel.BOD;
            _employee.Gender = _employeeDetailsViewModel.Gender;
            _employee.Address = _employeeDetailsViewModel.Address;
            _employee.PhoneNo = _employeeDetailsViewModel.Phone;
            _employee.Email = _employeeDetailsViewModel.Email;

            MessageBox.Show(_employee.ToString());
        }
    }
}
