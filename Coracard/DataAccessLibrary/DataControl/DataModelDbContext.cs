using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLibrary.DataControl
{
    public partial class DataModelDbContext : DbContext
    {
        public DataModelDbContext()
            : base("name=DataModelDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Social> Socials { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Posts)
                .Map(m => m.ToTable("PostTag").MapLeftKey("POSTID").MapRightKey("TAGID"));

            modelBuilder.Entity<Social>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Social>()
                .Property(e => e.LINK)
                .IsUnicode(false);

            modelBuilder.Entity<Social>()
                .Property(e => e.IMAGE)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tag>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Contacts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Posts)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("UserRole").MapLeftKey("USERID").MapRightKey("ROLEID"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Socials)
                .WithMany(e => e.Users)
                .Map(m => m.ToTable("UserSocial").MapLeftKey("USERID").MapRightKey("SOCIALID"));
        }
    }
}
