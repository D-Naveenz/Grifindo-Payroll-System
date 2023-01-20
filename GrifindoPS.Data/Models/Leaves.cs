using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Data.Models
{
    public class Leaves
    {
        public Leaves()
        {
            Date = DateTime.Now.Date;
            Approval = false;
        }

        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public bool Approval { get; set; }

        public void Approve()
        {
            Approval = true;
        }
    }
}
