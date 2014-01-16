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
        public CharacterVM ConvertCharacter(Character character)
        {
            CharacterVM charVM = new CharacterVM();
            charVM.ID = character.ID;
            charVM.Name = character.Name;
            charVM.Alignment = character.Alignment;
            charVM.Foreign = character.Foreign;
            return charVM;
        }
        public Character ConvertCharacter(CharacterVM charVM)
        {
            Character character = new Character();
            character.ID = charVM.ID;
            character.Name = charVM.Name;
            character.Alignment = charVM.Alignment;
            character.Foreign = charVM.Foreign;
            return character;
        }
        public List<CharacterVM> GetUserCharacters(int u_id)
        {
            List<CharacterVM> charsVM = new List<CharacterVM>();
            CharacterDAO dao = new CharacterDAO();
            List<Character> characters = dao.GetUserCharacters(u_id);
            foreach (Character character in characters)
            {
                charsVM.Add(ConvertCharacter(character));
            }
            return charsVM;
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