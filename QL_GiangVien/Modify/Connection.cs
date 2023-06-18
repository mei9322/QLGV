using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QL_GiangVien.Modify
{
    class Connection
    {
        private static string connectionString = @"Data Source=DESKTOP-IHLHQSB\SQLEXPRESS;Initial Catalog=db_moi;Integrated Security=True";

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }

    }
}
