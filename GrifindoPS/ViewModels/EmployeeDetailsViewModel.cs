using GrifindoPS.Commands;
using GrifindoPS.Models;
using GrifindoPS.Services;
using GrifindoPS.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GrifindoPS.ViewModels
{
    internal class EmployeeDetailsViewModel : ViewModelBase
    {
        private EmployeeModel? _employee;
        private ObservableCollection<string> _roles;
        private Guid _id;
        private string _name = string.Empty;
        private string _role = string.Empty;
        private DateTime _bod = new(2000, 1, 1);
        private string _gender = "Male";
        private string? _address;
        private string? _phone;
        private string? _email;

        private double _monthlySalary;
        private double _otRate;
        private double _allowance;

        public EmployeeDetailsViewModel(NavigationService empListNavigationService, NavigationService leavesNavigationService)
        {
            _employee = ConfigStore.Instance.CurrentEmployee;

            if (_employee == null)
            {
                // Setup to the registration
                SubmitName = "Register";
                SubmitCommand = new EmployeeRegisterCommand(this, empListNavigationService);
            }
            else
            {
                // Setup to the update
                SubmitName = "Update";

                _id = _employee.Id;
                _name = _employee.Name;
                _role = _employee.Role;
                _bod = _employee.Birthday;
                _gender = _employee.Gender;
                _address = _employee.Address;
                _phone = _employee.PhoneNo;
                _email = _employee.Email;

                _monthlySalary = _employee.MonthlySalary;
                _otRate = _employee.OtRate;
                _allowance = _employee.Allowance;

                SubmitCommand = new EmployeeUpdateCommand(this, empListNavigationService);
            }

            _roles = new()
            {
                "Admin",
                "Manager",
                "Staff"
            };
            LeavesCommand = new EmployeeLeavesCommand(this, leavesNavigationService);
            CancelCommand = new NavigationCommand(empListNavigationService);
        }

        public Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Role
        {
            get { return _role; }
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public DateTime BOD
        {
            get { return _bod; }
            set
            {
                if(_bod != value)
                {
                    _bod = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public string Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        public double MonthlySalary
        {
            get { return _monthlySalary; }
            set
            {
                if (_monthlySalary != value)
                {
                    _monthlySalary = value;
                    OnPropertyChanged();
                }
            }
        }

        public double OtRate
        {
            get { return _otRate; }
            set
            {
                if (_otRate != value)
                {
                    _otRate = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Allowance
        {
            get { return _allowance; }
            set
            {
                if (_allowance != value)
                {
                    _allowance = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Absent
        {
            get
            {
                if (_employee == null)
                {
                    return 0;
                }
                else
                {
                    return _employee.Leave.Count;
                }
            }
        }

        public double BasePay
        {
            get
            {
                if (_employee == null)
                {
                    return 0;
                }
                else
                {
                    return _employee.MonthlySalary + _employee.Allowance + (_employee.OtRate);
                }
            }
        }

        public double GrossPay
        {
            get
            {
                if (_employee == null)
                {
                    return 0;
                }
                else
                {
                    double noPay = _employee.MonthlySalary / Config.Instance.CycleRange().Days * Absent;
                    return BasePay - (noPay + BasePay * Config.Instance.GvtTax);
                }
            }
        }

        public ICommand LeavesCommand { get; }

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public string SubmitName { get; }

        public EmployeeModel? Employee => _employee;

        public IEnumerable<string> Roles => _roles;
            
    }
}
