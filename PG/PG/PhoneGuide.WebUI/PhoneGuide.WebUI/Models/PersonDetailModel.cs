using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneGuide.WebUI.Models
{
    public class PersonDetailModel
    {

        public Persons Person { get; set; }
        public List<Phones> Phones { get; set; }

    }
}