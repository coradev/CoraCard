using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class SocialDAO
    {
        public static void AddUserSocial(int uid, int sid)
        {
            SqlCommand sql = new SqlCommand(@"INSERT INTO UserSocial VALUES (@uid, @sid)");
            sql.Parameters.AddWithValue("@uid", uid);
            sql.Parameters.AddWithValue("@sid", sid);
            DAO.GetDataTable(sql);
        }
    }
}
