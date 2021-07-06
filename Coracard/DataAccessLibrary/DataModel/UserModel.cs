using DataAccessLibrary.DataControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    //waiting active email
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
                {
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
