using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneGuide.API.Models
{
    public class PhonesModel
    {
        public int TelephoneID { get; set; }
        public int PersonID { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }
    }
}