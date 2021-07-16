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
    }
}
