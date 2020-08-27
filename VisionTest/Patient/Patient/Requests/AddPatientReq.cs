using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient
{
    public class AddPatientReq
    {
        public String User { get; set; }
        public String ForeName { get; set; }
        public String Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String PrimaryContactNumber { get; set; }
        public String PrimaryAddressLine1 { get; set; }
        public String PrimaryAddressLine2 { get; set; }
        public String PrimaryAddressLine3 { get; set; }
        public String PostCode { get; set; }
    }
}
