using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class StatisticsDAO
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
        public List<Statistics> ReadStats(string statement, SqlParameter[] parameters)
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
                    List<Statistics> stats = new List<Statistics>();
                    while (data.Read())
                    {
                        Statistics stat = new Statistics();
                        stat.ID = Convert.ToInt32(data["stat_id"]);
                        stat.Strength = data["Strength"].ToString();
                        stat.Intelligence = data["Intelligence"].ToString();
                        stat.Dexterity = data["Dexterity"].ToString();
                        stat.Foreign = Convert.ToInt32(data["c_id"]);
                        stats.Add(stat);
                    }
                    try
                    {
                        return stats;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
        public void CreateStats(Statistics stat)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@c_id", stat.Foreign)
            };
            Write("CreateStats", parameters);
        }
        public List<Statistics> GetCharacterStats(int c_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@c_id", c_id)
            };
            return ReadStats("GetCharacterStats", parameters);
        }
    }
}