namespace DataAccessLibrary.DataControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Post")]
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            Tags = new HashSet<Tag>();
        }

        public int POSTID { get; set; }

        [Required]
        [StringLength(500)]
        public string TITLE { get; set; }

        [Required]
        public string DESCRIPTION { get; set; }

        [Required]
        public string CONTENT { get; set; }

        [Column(TypeName = "date")]
        public DateTime UPDATETIME { get; set; }

        public int CATEGORYID { get; set; }

        public int USERID { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
