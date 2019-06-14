using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneGuide.WebUI.Models
{
    public class Phones
    {
        public int TelephoneID { get; set; }
        public int PersonID { get; set; }
        public string Category { get; set; }
        public string PhoneNumber { get; set; }
    }
}
