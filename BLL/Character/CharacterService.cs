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
        public void CreateCharacters(CharacterFM characterFM)
        {
            CharacterDAO dao = new CharacterDAO();
            Character character = new Character();
            character.Name = characterFM.Name;
            character.Alignment = characterFM.Alignment;
            dao.CreateCharacter(character);
        }
        public void RemoveUser(int ID)
        {
            CharacterDAO dao = new CharacterDAO();
            dao.RemoveCharacter(ID);
        }
        public bool NameLength(string name)
        {
            if (name != null && name.Length > 26)
            {
                return true;
            }
            return false;
        }

    }
}