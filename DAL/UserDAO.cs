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
        public List<User> ReadUsers(string statement, SqlParameter[] parameters)
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
                    List<User> users = new List<User>();
                    while (data.Read())
                    {
                        User user = new User();
                        user.ID = Convert.ToInt32(data["u_id"]);
                        user.Username = data["Username"].ToString();
                        user.Email = data["Email"].ToString();
                        user.Password = data["Password"].ToString();
                        users.Add(user);
                    }
                    try
                    {
                        return users;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
        public void CreateUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password),
            };
            Write("CreateUser", parameters);
        }
        public User GetUserByID(int ID)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@u_id", ID)
                };
                return ReadUsers("GetUserByID", parameters).SingleOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: \n" + e.Message);
                Console.ReadKey();
                return null;
            }
        }
        public User GetUser(string email)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", email),
                new SqlParameter("@Username", email)
            };
            return ReadUsers("GetUser", parameters).SingleOrDefault();
        }
        public User GetUserByEmail(string email)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", email)
            };
            return ReadUsers("GetUserByEmail", parameters).SingleOrDefault();
        }
        public User GetUserByUsername(string username)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Username", username)
            };
            return ReadUsers("GetUserByUsername", parameters).SingleOrDefault();
        }
        public List<User> GetAllUsers()
        {
            return ReadUsers("GetAllUsers", null);
        }
        public void UpdateUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@u_id", user.ID),
                new SqlParameter("@Username", user.Username),
                new SqlParameter("@Email", user.Email),
                new SqlParameter("@Password", user.Password)
            };
            Write("UpdateUser", parameters);
        }
        public void RemoveUser(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@u_id", ID),
            };
            Write("RemoveUser", parameters);
        }
    }
}