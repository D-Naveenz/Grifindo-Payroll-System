using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrifindoPS.Models;

public partial class LeaveModel
{
    public LeaveModel(Guid id, DateTime date, string? description, EmployeeModel emp, string approval = null)
    {
        Id = id;
        Date = date;
        Description = description ?? "N/A";
        Approval = approval;
        Emp = emp;
    }

    public Guid Id { get; }
    public DateTime Date { get; }
    public string Description { get; }
    public string Approval { get; }
    public EmployeeModel Emp { get; }
}