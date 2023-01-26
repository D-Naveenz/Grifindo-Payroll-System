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
        private string _email;

        private double _monthlySalary;
        private double _allowance;
        private double _otRate;
        private double _otHours;

        private int _absent;
        private double _noPay;
        private double _basePay;
        private double _grossPay;

        public EmployeeDetailsViewModel(NavigationService empListNavigationService, NavigationService leavesNavigationService)
        {
            _employee = RuntimeStore.Instance.CurrentEmployee;

            if (_employee == null)
            {
                // Setup to the registration
                SubmitName = "Register";

                _email = string.Empty;
                
                _absent = 0;
                _noPay = 0;
                _basePay = 0;
                _grossPay = 0;

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
                _email = _employee.Email;

                _monthlySalary = _employee.MonthlySalary;
                _allowance = _employee.Allowance;
                _otRate = _employee.OtRate;
                _otHours = _employee.OtHours;

                SubmitCommand = new EmployeeUpdateCommand(this, empListNavigationService);
            }

            _roles = new()
            {
                "Admin",
                "Manager",
                "Staff"
            };

            LoadAbcentsCommand = new LoadNoOfAbcents(this);
            LeavesCommand = new EmployeeLeavesCommand(this, leavesNavigationService);
            CancelCommand = new NavigationCommand(empListNavigationService);
        }

        public static EmployeeDetailsViewModel LoadViewModel(NavigationService empListNavigationService, NavigationService leavesNavigationService)
        {
            EmployeeDetailsViewModel viewModel = new(empListNavigationService, leavesNavigationService);
            if (RuntimeStore.Instance.CurrentEmployee != null) viewModel.LoadAbcentsCommand.Execute(null);
            return viewModel;
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
        
        public DateTime Birthday
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

        public string Email
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

        public double OtHours
        {
            get { return _otHours; }
            set
            {
                if (_otHours != value)
                {
                    _otHours = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Absent
        {
            get { return _absent; }
            set
            {
                if (_absent != value)
                {
                    _absent = value;
                    OnPropertyChanged();
                }
            }
        }

        public double NoPay
        {
            get { return _noPay; }
            set
            {
                if (_noPay != value)
                {
                    _noPay = value;
                    OnPropertyChanged();
                }
            }
        }

        public double BasePay
        {
            get { return _basePay; }
            set
            {
                if (_basePay != value)
                {
                    _basePay = value;
                    OnPropertyChanged();
                }
            }
        }

        public double GrossPay
        {
            get { return _grossPay; }
            set
            {
                if (_grossPay != value)
                {
                    _grossPay = value;
                    OnPropertyChanged();
                }
            }
        }

        public LoadNoOfAbcents LoadAbcentsCommand { get; }

        public ICommand LeavesCommand { get; }

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public string SubmitName { get; }

        public IEnumerable<string> Roles => _roles;
    }
}
