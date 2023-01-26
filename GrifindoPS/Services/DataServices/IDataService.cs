using GrifindoPS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Services.DataServices
{
    internal interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(Guid id);
        Task Add(T item);
        Task Update(T item);
        Task<bool> Delete(T item);
    }
}
