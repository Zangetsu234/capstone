using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CharacterService
    {
        public bool CreateCharacter(CharacterFM characterFM)
        {
            if (CharacterNameLength(characterFM))
            {
                CharacterDAO dao = new CharacterDAO();
                Character character = new Character();
                character.Name = characterFM.Name;
                character.Alignment = characterFM.Alignment;
                character.Foreign = characterFM.Foreign;
                dao.CreateCharacter(character);
                return true;
            }
            return false;
        }
        public List<Character> GetAllCharacters()
        {
            List<Character> charList = new List<Character>();
            CharacterDAO dao = new CharacterDAO();
            List<Character> characters = dao.GetUserCharacters();
            foreach (Character character in characters)
            {
                charList.Add(character);
            }
            return charList;
        }
        public void RemoveCharacter(int ID)
        {
            CharacterDAO dao = new CharacterDAO();
            dao.RemoveCharacter(ID);
        }
        public bool CharacterNameLength(CharacterFM charFM)
        {
            UserDAO dao = new UserDAO();
            if (charFM.Name != null && charFM.Name.Length < 26)
            {
                return true;
            }
            return false;
        }
    }
}