using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient
{
    public class Patient
    {
        public Guid Id { get; set; }
        public String Forename { get; set; }
        public String Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Guid PrimaryContactPhoneID { get; set; }
        public Guid PrimaryAddressId { get; set; }

    }
}
