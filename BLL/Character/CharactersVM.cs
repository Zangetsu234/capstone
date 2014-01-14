using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CharactersVM
    {
        public List<CharacterVM> Characters { get; set; }
        public CharactersVM()
        {
            Characters = new List<CharacterVM>();
        }

    }
}