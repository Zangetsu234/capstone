using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class CharacterDAO
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
        public List<Character> ReadCharacters(string statement, SqlParameter[] parameters)
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
                    List<Character> characters = new List<Character>();
                    while (data.Read())
                    {
                        Character character = new Character();
                        character.ID = Convert.ToInt32(data["ID"]);
                        character.Name = data["Name"].ToString();
                        character.Alignment = data["Alignment"].ToString();
                        character.Foreign = Convert.ToInt32(data["Foreign"]);
                        characters.Add(character);
                    }
                    try
                    {
                        return characters;
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
        }
        public void CreateCharacter(Character character)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", character.Name),
                new SqlParameter("@u_id", character.Foreign)
            };
            Write("CreateCharacter", parameters);
        }
        public List<Character> GetAllCharacters()
        {
            return ReadCharacters("GetAllCharacters", null);
        }
        public void RemoveCharacter(int ID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@c_id", ID)
            };
            Write("RemoveCharacter", parameters);
        }
    }
}