﻿using GrifindoPS.Commands;
using GrifindoPS.Data.Models;
using GrifindoPS.Services;
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
        private Employee? _employee;
        private Salary _salary;
        private ObservableCollection<string> _roles;
        private string _id = string.Empty;
        private string _name = string.Empty;
        private string _role = string.Empty;
        private DateTime _bod = new(2000, 1, 1);
        private string _gender = "Male";
        private string? _address;
        private string? _phone;
        private string? _email;

        private float _monthlySalary;
        private float _otRate;
        private float _allowance;

        public EmployeeDetailsViewModel(NavigationService empListNavigationService, NavigationService leavesNavigationService)
        {
            _employee = Config.Instance.CurrentEmployee;
            
            if (_employee == null)
            {
                // Setup to the registration
                SubmitName = "Register";
                _employee = new();
                _salary = new();
                SubmitCommand = new EmployeeRegisterCommand(this, empListNavigationService);
            }
            else
            {
                // Setup to the update
                SubmitName = "Update";
                _salary = _employee.Salary;

                _id = _employee.Id;
                _name = _employee.Name;
                _role = _employee.Role;
                _bod = _employee.BOD;
                _gender = _employee.Gender;
                _address = _employee.Address;
                _phone = _employee.PhoneNo;
                _email = _employee.Email;

                _monthlySalary = _salary.MonthlySalary;
                _otRate = _salary.OtRate;
                _allowance = _salary.Allowance;

                SubmitCommand = new EmployeeUpdateCommand(this);
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

        public void Reset()
        {
            _id = string.Empty;
            _name = string.Empty;
            _role = string.Empty;
            _bod = new(2000, 1, 1);
            //_gender = Gender.Male;
            _address = string.Empty;
            _phone = string.Empty;
            _email = string.Empty;

            _monthlySalary = 0;
            _otRate = 0;
            _allowance = 0;
        }

        public string Id
        {
            get { return _id; }
            set {
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

        public float MonthlySalary
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

        public float OtRate
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

        public float Allowance
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

        public int Absent { get; }

        public float BasePay { get; }

        public float GrossPay { get; }

        public ICommand LeavesCommand { get; }

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public string SubmitName { get; }

        public Employee? Employee => _employee;

        public Salary Salary => _salary;

        public IEnumerable<string> Roles => _roles;
    }
}
