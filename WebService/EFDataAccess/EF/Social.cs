namespace EFDataAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Social")]
    public partial class Social
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Social()
        {
            Users = new HashSet<User>();
        }

        public int SOCIALID { get; set; }

        [Required]
        [StringLength(500)]
        public string NAME { get; set; }

        [Required]
        [StringLength(500)]
        public string LINK { get; set; }

        [Required]
        public string IMAGE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
