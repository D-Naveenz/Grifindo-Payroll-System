using GrifindoPS.DTOs;
using GrifindoPS.Models;
using GrifindoPS.Services.DataServices;
using GrifindoPS.Stores;
using GrifindoPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrifindoPS.Commands
{
    class LoadNoOfAbcents : AsyncCommndBase
    {
        private readonly EmployeeDetailsViewModel _employeeDetailsViewModel;
        private readonly IDataService<EmployeeModel> _employeeDataService = ConfigStore.Instance.EmployeeDataService;

        public LoadNoOfAbcents(EmployeeDetailsViewModel employeeDetailsViewModel)
        {
            _employeeDetailsViewModel = employeeDetailsViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            int _absent;
            double _noPay;
            double _basePay;
            double _grossPay;
            
            try
            {
                var result = await ConfigStore.Instance.EmployeeDataService.GetAllLeaves(ConfigStore.Instance.CurrentEmployee);
                _absent = result.Count();
                _noPay = _employeeDetailsViewModel.MonthlySalary / Config.Instance.CycleRange().Days * _absent;
                _basePay = _employeeDetailsViewModel.MonthlySalary + _employeeDetailsViewModel.Allowance + _employeeDetailsViewModel.OtRate * _employeeDetailsViewModel.OtHours;
                _grossPay = _basePay - (_noPay + Config.Instance.GvtTax);

                _employeeDetailsViewModel.Absent = _absent;
                _employeeDetailsViewModel.NoPay = _noPay;
                _employeeDetailsViewModel.BasePay = _basePay;
                _employeeDetailsViewModel.GrossPay = _grossPay;
            }
            catch (Exception ex)
            {

                MessageBox.Show("The Employee No Of Abcents loading failed!\n" + ex, "GrifindoPS: Error - Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
