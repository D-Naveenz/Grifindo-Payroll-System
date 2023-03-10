using GrifindoPS.DBContexts;
using GrifindoPS.DTOs;
using GrifindoPS.Models;
using GrifindoPS.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrifindoPS.Services.DataServices
{
    internal class LeaveDataService : IDataService<LeaveModel>
    {
        private GrifindoContextFactory _dbContextFactory;

        public LeaveDataService(GrifindoContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Add(LeaveModel item)
        {
            try
            {
                using GrifindoContext dBContext = _dbContextFactory.CreateDbContext();
                var employee = await dBContext.Employee.Include(e => e.Leave).FirstOrDefaultAsync(e => e.Id == item.Emp.Id);
                if (employee == null)
                {
                    throw new Exception("Employee not found");
                }

                var leave = new Leave
                {
                    Date = item.Date,
                    Description = item.Description,
                    Approval = item.Approval,
                    EmpId = employee.Id
                };
                dBContext.Leave.Add(leave);
                await dBContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        public async Task<bool> Delete(LeaveModel item)
        {
            using GrifindoContext dBContext = _dbContextFactory.CreateDbContext();
            dBContext.Leave.Remove(ToEntity(item));
            await dBContext.SaveChangesAsync();
            return true;
        }
        
        public async Task<LeaveModel?> Get(Guid id)
        {
            using GrifindoContext dBContext = _dbContextFactory.CreateDbContext();
            Leave? leave = await dBContext.Leave.SingleOrDefaultAsync(e => e.Id == id);
            return ToNullableModel(leave);
        }
        
        public async Task<IEnumerable<LeaveModel>> GetAll()
        {
            using GrifindoContext dBContext = _dbContextFactory.CreateDbContext();
            IEnumerable<Leave> leaves = await dBContext.Leave.ToListAsync();
            return leaves.Select(e => ToModel(e));
        }

        public async Task Update(LeaveModel item)
        {
            using GrifindoContext dBContext = _dbContextFactory.CreateDbContext();
            dBContext.Leave.Update(ToEntity(item));
            await dBContext.SaveChangesAsync();
        }

        public static Leave ToEntity(LeaveModel item)
        {
            return new()
            {
                Id = item.Id,
                Date = item.Date,
                Description = item.Description,
                Approval = item.Approval,
                EmpId = item.Emp.Id,
            };
        }

        public static LeaveModel ToModel(Leave item)
        {
            return new(
                item.Id,
                item.Date,
                item.Description,
                EmployeeDataService.ToModel(item.Emp),
                item.Approval
                );
        }

        public static LeaveModel? ToNullableModel(Leave? item)
        {
            if (item == null) return null;
            
            return new(
                item.Id,
                item.Date,
                item.Description,
                EmployeeDataService.ToModel(item.Emp),
                item.Approval
                );
        }
    }
}
