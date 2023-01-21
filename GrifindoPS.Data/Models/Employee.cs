﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Data.Models
{
    public enum Gender
    {
        Male, Female
    }
    
    public class Employee
    {
        private readonly Salary _salary;
        private readonly List<Leaves> _leaves;

        public Employee()
        {
            _salary = new();
            _leaves = new List<Leaves>();

            Id = "";
            Name = "";
            Role = new();
            BOD = DateTime.Now.Date;
            Gender = Gender.Male;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
        public DateTime BOD { get; set; }
        public Gender Gender { get; set; }
        public string? Address { get; set; }
        public string? PhoneNo { get; set; }
        public string? Email { get; set; }
    }
}
