using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrifindoPS.Models;

public partial class EmployeeModel
{
    public EmployeeModel(Guid id, string name, string role, DateTime birthday, string gender, string email, double monthlySalary, double? allowance = null, double? otRate = null, double? otHours = null)
    {
        Id = id;
        Name = name;
        Role = role;
        Birthday = birthday;
        Gender = gender;
        Email = email != "" ? email : "N/A";
        MonthlySalary = monthlySalary;
        Allowance = allowance ?? 0;
        OtRate = otRate ?? 0;
        OtHours = otHours ?? 0;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Role { get; }
    public DateTime Birthday { get; }
    public string Gender { get; }
    public string Email { get; }
    public double MonthlySalary { get; }
    public double Allowance { get; }
    public double OtRate { get; }
    public double OtHours { get; }
}