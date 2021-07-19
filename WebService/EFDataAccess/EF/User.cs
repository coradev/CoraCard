namespace EFDataAccess.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Contacts = new HashSet<Contact>();
            Posts = new HashSet<Post>();
            Roles = new HashSet<Role>();
            Socials = new HashSet<Social>();
        }

        public int USERID { get; set; }

        [Required]
        [StringLength(50)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(500)]
        public string PASSWORD { get; set; }

        [Required]
        [StringLength(500)]
        public string AVATAR { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [StringLength(100)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(100)]
        public string FULLNAME { get; set; }

        [Required]
        public string BIOGRAPHY { get; set; }

        public int STATUSID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }

        public virtual Status Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Role> Roles { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Social> Socials { get; set; }
    }
}
