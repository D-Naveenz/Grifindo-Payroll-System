using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrifindoPS.Models
{
    public class Leave
    {
        public Leave()
        {
            RecordTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            EmpID = string.Empty;
            Date = DateTime.Now.Date;
            Approval = string.Empty;
        }

        public Leave(Employee employee, DateTime date, string? description, string approval)
        {
            RecordTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            EmpID = employee.Id;
            Date = date;
            Description = description;
            Approval = approval;
        }
        
        public long RecordTime { get; }
        public string EmpID { get; }
        public DateTime Date { get; }
        public string? Description { get; }
        public string Approval { get; }
    }
}
