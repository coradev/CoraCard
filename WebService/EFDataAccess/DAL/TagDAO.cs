using EFDataAccess.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.DAL
{
    public class TagDAO
    {
        CoraCardDBContext db = null;
        public TagDAO()
        {
            db = new CoraCardDBContext();
        }

        public DbSet<Tag> GetAllTag()
        {
            return db.Tags;
        }

        public int AddNewTag(Tag entity)
        {
            db.Tags.Add(entity);
            db.SaveChanges();
            return entity.TAGID;
        }
    }
}
