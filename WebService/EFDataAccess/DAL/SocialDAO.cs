using EFDataAccess.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccess.DAL
{
    public class SocialDAO
    {
        CoraCardDBContext db = null;

        public SocialDAO()
        {
            db = new CoraCardDBContext();
        }

        public int AddSocial(Social entity)
        {
            db.Socials.Add(entity);
            db.SaveChanges();
            return entity.SOCIALID;
        }

        public bool EditSocial(Social entity)
        {
            try
            {
                Social social = db.Socials.Find(entity.SOCIALID);
                social.NAME = entity.NAME;
                social.LINK = entity.LINK;
                social.IMAGE = entity.IMAGE;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Social> ListAllSocialsByUserId(int uid)
        {
            return db.Users.Find(uid).Socials.ToList();
        }

        public Social GetSocial(int sid)
        {
            return db.Socials.Find(sid);
        }

        public bool DeleteSocial(int sid)
        {
            try
            {
                Social social = db.Socials.Find(sid);
                db.Socials.Remove(social);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
