using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiClient.Http
{
    public class APIModel
    {
        public String User { get; set; }
        public String Forename { get; set; }
        public String Surname { get; set; }
        public String DateOfBirth { get; set; }
        public String PrimaryContactNumber { get; set; }
        public String PrimaryAddressLine1 { get; set; }
        public String PrimaryAddressLine2 { get; set; }
        public String PrimaryAddressLine3 { get; set; }
        public String PostCode { get; set; }
    }
}
