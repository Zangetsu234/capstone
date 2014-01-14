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
        public CharactersVM GetUsers()
        {
            CharacterDAO dao = new CharacterDAO();
            List<Character> characters = dao.GetAllCharacters();
            CharactersVM charactersVM = new CharactersVM();
            foreach(Character character in characters)
            {
                CharacterVM characterVM = new CharacterVM();
                characterVM.ID = character.ID;
                characterVM.Name = character.Name;
                characterVM.Alignment = character.Alignment;
                charactersVM.Characters.Add(characterVM);
            }
            return charactersVM;
        }
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
        public void RemoveUser(int ID)
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