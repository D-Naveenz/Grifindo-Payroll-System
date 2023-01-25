﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using GrifindoPS.Models;
using Microsoft.EntityFrameworkCore;

namespace GrifindoPS.DBContexts;

public partial class GrifindoContext : DbContext
{
    public GrifindoContext()
    {
    }

    public GrifindoContext(DbContextOptions<GrifindoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<Leave> Leave { get; set; }

    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    /*
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=NAVEENZ-ROG;Initial Catalog=Grifindo;Integrated Security=True");
     */

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Leave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmpLeaves");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Emp).WithMany(p => p.Leave).HasConstraintName("FK_EmpLeaves_Employee1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}