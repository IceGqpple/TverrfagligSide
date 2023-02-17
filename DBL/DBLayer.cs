using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBL
{
    public class DBLayer
    {
        public int GetUserCountByEmail(string email)
        {
            return 0;
        }
        public int GetUserCountByUsername(string username, string password)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
            SqlParameter param;
            int count = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(id) AS Count FROM users WHERE username = @username AND password = @password", conn);
                cmd.CommandType = CommandType.Text;
                
                param = new SqlParameter("@username", SqlDbType.NVarChar);
                param.Value = username;
                cmd.Parameters.Add(param);

                param = new SqlParameter("@password", SqlDbType.NVarChar);
                param.Value = password;
                cmd.Parameters.Add(param);

                count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }
        public int InsertUser(string username, string password, string mail)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ConnAir"].ConnectionString;
            using (var con = new SqlConnection(connectionString))
            {
                int newID;
                var cmd = "INSERT INTO users (username, password, mail) VALUES (@username, @password, @mail);SELECT CAST(scope_identity() AS int)";
                using (var insertCommand = new SqlCommand(cmd, con))
                {
                    insertCommand.Parameters.AddWithValue("@username", username);
                    insertCommand.Parameters.AddWithValue("@password", password);
                    insertCommand.Parameters.AddWithValue("@mail", mail);
                    con.Open();
                    newID = (int)insertCommand.ExecuteScalar();
                }
                return newID;
            }
        }
    }
}
