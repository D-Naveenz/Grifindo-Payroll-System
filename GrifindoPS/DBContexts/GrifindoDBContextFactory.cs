using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.DBContexts
{
    internal class GrifindoDBContextFactory
    {
        private readonly string _connectionstring;

        public GrifindoDBContextFactory(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public GrifindoContext CreateDbContext()
        {
            DbContextOptions<GrifindoContext> options = new DbContextOptionsBuilder<GrifindoContext>().UseSqlServer(_connectionstring).Options;
            return new GrifindoContext(options);
        }
    }
}
