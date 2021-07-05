namespace DataAccessLibrary.DataControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int CONTACTID { get; set; }

        [Required]
        [StringLength(100)]
        public string NAME { get; set; }

        [Required]
        [StringLength(100)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(500)]
        public string CONTENT { get; set; }

        public int USERID { get; set; }

        public virtual User User { get; set; }
    }
}
