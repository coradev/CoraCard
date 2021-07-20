using EFDataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.DAL
{
    public class PostDAO
    {
        CoraCardDBContext db = null;

        public PostDAO()
        {
            db = new CoraCardDBContext();
        }

        public int AddPost(Post entity)
        {
            db.Posts.Add(entity);
            db.SaveChanges();
            return entity.POSTID;
        }


    }
}
