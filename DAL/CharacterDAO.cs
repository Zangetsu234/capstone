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
                        character.CharID = Convert.ToInt32(data["c_id"]);
                        character.Name = data["Name"].ToString();
                        character.Alignment = Convert.ToBoolean(data["Alignment"]);
                        character.Foreign = Convert.ToInt32(data["u_id"]);
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
                new SqlParameter("@Alignment", character.Alignment),
                new SqlParameter("@u_id", character.Foreign)
            };
            Write("CreateCharacter", parameters);
        }
        public List<Character> GetUserCharacters(int u_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@u_id", u_id)
            };
            return ReadCharacters("GetUserCharacters", parameters);
        }
        public void RemoveCharacter(int CharID)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@c_id", CharID)
            };
            Write("RemoveCharacter", parameters);
        }
        public Character GetCharacterByName(string name)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", name)
            };
            return ReadCharacters("GetCharacterByName", parameters).SingleOrDefault();
        }
        public Character GetCharacterByID(int c_id)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@c_id", c_id)
            };
            return ReadCharacters("GetCharacterByID", parameters).SingleOrDefault();
        }
        public List<Character> GetAllCharacters()
        {
            return ReadCharacters("GetAllCharacters", null);
        }
    }
}