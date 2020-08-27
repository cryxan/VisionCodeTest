using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patient
{
    public class Address
    {
        public Guid Id { get; set; }
        public String Line1 { get; set; }
        public String Line2 { get; set; }
        public String Line3 { get; set; }
        public String PostCode { get; set; }

    }
}
