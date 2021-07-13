using DataAccessLibrary.DataControl;
using System.Linq;

namespace DataAccessLibrary.DataModel
{
    public class UserModel
    {
        DataModelDbContext db = null;
        public UserModel()
        {
            db = new DataModelDbContext();
        }

        public int Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.USERID;
        }

        public User GetByUserName(string UserName)
        {
            return db.Users.SingleOrDefault(x => x.USERNAME == UserName);
        }

        public User GetByUserId(int? id)
        {
            return db.Users.Find(id);
        }

        public bool UpdateUser(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.USERID);
                user.EMAIL = entity.EMAIL;
                user.FULLNAME = entity.FULLNAME;
                user.BIOGRAPHY = entity.BIOGRAPHY;
                user.STATUSID = entity.STATUSID;
                db.SaveChanges();
                return true;
            }catch
            {
                return false;
            }
        }

        public bool UpdateUserPassword(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.USERID);
                user.PASSWORD = entity.PASSWORD;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Login(string userName, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.USERNAME == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.STATUSID != 1)
                {
                    // waiting active email
                    if (result.STATUSID == 2)
                    {
                        return -1;
                    }
                    else
                    {
                        // user banned
                        return -2;
                    }
                }
                else
                {   // check password 
                    if (result.PASSWORD == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -3;
                    }
                }
            }
        }
    }
}
