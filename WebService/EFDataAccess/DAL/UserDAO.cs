using EFDataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.DAL
{
    public class UserDAO
    {
        CoraCardDBContext db = null;

        public UserDAO()
        {
            db = new CoraCardDBContext();
        }

        public int Login(string UserName, string Password)
        {
            var result = db.Users.SingleOrDefault(x => x.USERNAME == UserName);
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
                    if (result.PASSWORD == Password)
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

        public User GetUserByUserName(string UserName)
        {
            return db.Users.SingleOrDefault(x => x.USERNAME == UserName);
        }

        //public int GetUserRole(string UserName)
        //{
        //    var userRoles = GetUserByUserName(UserName).Roles.Select(r => r.ROLEID);
        //    var roles = db.Roles.Where(r => userRoles.Contains(r.ROLEID));
        //    return roles.Select(r => r.ROLEID).First();
        //}
    }
}
