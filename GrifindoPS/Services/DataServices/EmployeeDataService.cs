using GrifindoPS.DBContexts;
using GrifindoPS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Services.DataServices
{
    internal class EmployeeDataService : IDataService<Employee>
    {
        private readonly GrifindoDBContextFactory _grifindoDBContextFactory;

        public EmployeeDataService(GrifindoDBContextFactory grifindoDBContextFactory)
        {
            _grifindoDBContextFactory = grifindoDBContextFactory;
        }

        public async Task Add(Employee item)
        {
            using GrifindoDBContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            dBContext.Employees.Add(item);
            await dBContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(Employee item)
        {
            using GrifindoDBContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            dBContext.Employees.Remove(item);
            await dBContext.SaveChangesAsync();
            return true;
        }

        public async Task<Employee?> Get(Guid id)
        {
            using GrifindoDBContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            Employee? employee = await dBContext.Employees.FindAsync(id);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            using GrifindoDBContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            return await dBContext.Employees.ToListAsync();
        }

        public async Task Update(Employee item)
        {
            using GrifindoDBContext dBContext = _grifindoDBContextFactory.CreateDbContext();
            dBContext.Employees.Update(item);
            await dBContext.SaveChangesAsync();
        }
    }
}
