// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrifindoPS.DTOs;

public partial class Employee
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(32)]
    public string Name { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string Role { get; set; }

    [Column(TypeName = "date")]
    public DateTime Birthday { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string Gender { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Email { get; set; }

    public double MonthlySalary { get; set; }

    public double? Allowance { get; set; }

    public double? OtRate { get; set; }

    public double? OtHours { get; set; }

    [InverseProperty("Emp")]
    public virtual ICollection<Leave> Leave { get; } = new List<Leave>();
}