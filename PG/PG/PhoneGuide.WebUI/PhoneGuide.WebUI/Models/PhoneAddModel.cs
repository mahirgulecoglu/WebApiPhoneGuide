using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneGuide.WebUI.Models
{
    public class PhoneAddModel
    {
        public string PhoneNumber { get; set; }
        public int PersonID { get; set; }
        public int CategoryID { get; set; }
    }
}