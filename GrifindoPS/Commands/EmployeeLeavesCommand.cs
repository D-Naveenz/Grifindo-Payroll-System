using GrifindoPS.Data.Models;
using GrifindoPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Commands
{
    public class EmployeeLeavesCommand : CommandBase
    {
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;

        public EmployeeLeavesCommand(EmployeeDetailsViewModel employeeDetailsViewModel)
        {
            _employeeDetailsViewModel = employeeDetailsViewModel;
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public override bool CanExecute(object? parameter)
        {
            return _employeeDetailsViewModel.SubmitName == "Update";
        }
    }
}
