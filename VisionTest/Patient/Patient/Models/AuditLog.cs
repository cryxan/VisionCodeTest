using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PatientID { get; set; }
        public DateTimeOffset DateTime {get; set;}
        public String Type { get; set; }
        public String Notes { get; set; }
    }
}
