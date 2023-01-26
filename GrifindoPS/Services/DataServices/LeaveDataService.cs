using GrifindoPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Services.DataServices
{
    internal class LeaveDataService : IDataService<Leave>
    {
        public Task Add(Leave item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Leave item)
        {
            throw new NotImplementedException();
        }

        public Task<Leave?> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Leave>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Leave item)
        {
            throw new NotImplementedException();
        }
    }
}
