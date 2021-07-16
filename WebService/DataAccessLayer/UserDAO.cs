using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UserDAO
    {
        public static void AddUserRole(int uid, int rid)
        {
            SqlCommand sql = new SqlCommand(@"INSERT INTO UserRole VALUES (@uid, @rid)");
            sql.Parameters.AddWithValue("@uid", uid);
            sql.Parameters.AddWithValue("@rid", rid);
            DAO.GetDataTable(sql);
        }
    }
}
