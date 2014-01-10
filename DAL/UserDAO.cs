using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDAO
    {
        public void Write(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=capstone;Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<User> ReadMarketMans(string statement, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=capstone;Integrated Security=SSPI;"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(statement, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    SqlDataReader data = command.ExecuteReader();
                    List<User> subscribers = new List<User>();
                    while (data.Read())
                    {
                        User user = new User();
                        user.ID = Convert.ToInt32(data["ID"]);
                        user.Email = data["Email"].ToString();
                        user.Password = data["Password"].ToString();
                        user.Add(user);
                    }
                    try
                    {
                        return subscribers;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }

    }
}