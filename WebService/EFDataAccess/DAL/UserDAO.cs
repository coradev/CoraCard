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

        public User GetUserByEmail(string UserEmail)
        {
            return db.Users.SingleOrDefault(x => x.EMAIL == UserEmail);
        }

        public int GetRoleIdByRoleName(string RoleName)
        {
            Role role = db.Roles.SingleOrDefault(x => x.NAME.ToLower() == RoleName.ToLower());
            return role.ROLEID;
        }

        public int AddUser(User entity)
        {
            User user = new User();
            user.USERNAME = entity.USERNAME;
            user.PASSWORD = entity.PASSWORD;
            user.AVATAR = "default.png";
            user.EMAIL = entity.EMAIL;
            user.FULLNAME = entity.FULLNAME;
            user.BIOGRAPHY = "New member of CoraCard";
            user.STATUSID = 1;
            db.Users.Add(user);
            db.SaveChanges();
            return user.USERID;
        }

        //public int GetUserRole(string UserName)
        //{
        //    var userRoles = GetUserByUserName(UserName).Roles.Select(r => r.ROLEID);
        //    var roles = db.Roles.Where(r => userRoles.Contains(r.ROLEID));
        //    return roles.Select(r => r.ROLEID).First();
        //}
    }
}
