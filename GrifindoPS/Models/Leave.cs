﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GrifindoPS.Models;

public partial class Leave
{
    [Key]
    [Column("ID")]
    public Guid Id { get; set; }

    [Column(TypeName = "date")]
    public DateTime Date { get; set; }

    [Column(TypeName = "ntext")]
    public string Description { get; set; }

    [Required]
    [StringLength(10)]
    [Unicode(false)]
    public string Approval { get; set; }

    [Column("EmpID")]
    public Guid EmpId { get; set; }

    [ForeignKey("EmpId")]
    [InverseProperty("Leave")]
    public virtual Employee Emp { get; set; }
}