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

        public List<Post> GetAllPost()
        {
            return db.Posts.ToList();
        }

        public Post GetPostById(int? id)
        {
            return db.Posts.Find(id);
        }

        public List<Post> GetPostExcludeById(int? id, int number)
        {
            return db.Posts.Where(x=> x.POSTID != id).Take(number).ToList();
        }


    }
}
