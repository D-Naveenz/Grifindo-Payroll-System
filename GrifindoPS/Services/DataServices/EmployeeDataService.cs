using GrifindoPS.DBContexts;
using GrifindoPS.DTOs;
using GrifindoPS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrifindoPS.Services.DataServices
{
    internal class EmployeeDataService : IDataService<EmployeeModel>
    {
        private readonly GrifindoContextFactory _grifindoDBContextFactory;

        public EmployeeDataService(GrifindoContextFactory grifindoDBContextFactory)
        {
            _grifindoDBContextFactory = grifindoDBContextFactory;
        }

        public async Task Add(EmployeeModel item)
        {
            using GrifindoContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            dBContext.Employee.Add(ToEntity(item));
            await dBContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(EmployeeModel item)
        {
            using GrifindoContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            dBContext.Employee.Remove(ToEntity(item));
            await dBContext.SaveChangesAsync();
            return true;
        }

        public async Task<EmployeeModel?> Get(Guid id)
        {
            using GrifindoContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            Employee? employee = await dBContext.Employee.SingleOrDefaultAsync(e => e.Id == id);
            return ToNullableModel(employee);
        }

        public async Task<IEnumerable<EmployeeModel>> GetAll()
        {
            using GrifindoContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            IEnumerable<Employee> employees = await dBContext.Employee.ToListAsync();
            return employees.Select(e => ToModel(e));
        }

        public async Task Update(EmployeeModel item)
        {
            using GrifindoContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            dBContext.Employee.Update(ToEntity(item));
            await dBContext.SaveChangesAsync();
        }

        public static Employee ToEntity(EmployeeModel item)
        {
            return new()
            {
                Id = item.Id,
                Name = item.Name,
                Role = item.Role,
                Birthday = item.Birthday,
                Gender = item.Gender,
                Email = item.Email,
                MonthlySalary = item.MonthlySalary,
                Allowance = item.Allowance,
                OtRate = item.OtRate,
                OtHours = item.OtHours
            };
        }

        public static EmployeeModel ToModel(Employee item)
        {
            return new(
                item.Id,
                item.Name,
                item.Role,
                item.Birthday,
                item.Gender,
                item.Email,
                item.MonthlySalary,
                item.Allowance,
                item.OtRate,
                item.OtHours
                );
        }

        public static EmployeeModel? ToNullableModel(Employee? item)
        {
            if (item == null) return null;

            return new(
                item.Id,
                item.Name,
                item.Role,
                item.Birthday,
                item.Gender,
                item.Email,
                item.MonthlySalary,
                item.Allowance,
                item.OtRate,
                item.OtHours
                );
        }
    }
}
