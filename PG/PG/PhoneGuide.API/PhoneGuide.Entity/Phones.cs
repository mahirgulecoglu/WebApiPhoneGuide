namespace PhoneGuide.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Phones
    {
        [Key]
        public int TelephoneID { get; set; }

        public int PersonID { get; set; }

        public int CategoryID { get; set; }

        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        public virtual Categories Categories { get; set; }

        public virtual Persons Persons { get; set; }
    }
}
