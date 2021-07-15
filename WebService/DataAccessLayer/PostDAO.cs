using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class PostDAO
    {
        //public static int GetNumberOfProduct()
        //{
        //    string sql = "SELECT count(*) FROM Products";
        //    DataTable dt = DAO.GetDataTable(sql);
        //    return Convert.ToInt32(dt.Rows[0][0]);
        //}

        //public static DataTable GetProductsByPage(int start, int size)
        //{
        //    SqlCommand sql = new SqlCommand(@"SELECT ProductID, ProductName, CategoryName, UnitPrice 
        //                    FROM Products P, Categories C
        //                    WHERE P.CategoryID = C.CategoryID 
        //                    ORDER BY ProductName
        //                    OFFSET @start ROWS
        //                    FETCH NEXT @size ROWS ONLY");
        //    sql.Parameters.AddWithValue("@start", start);
        //    sql.Parameters.AddWithValue("@size", size);
        //    return DAO.GetDataTable(sql);
        //}
    }
}
