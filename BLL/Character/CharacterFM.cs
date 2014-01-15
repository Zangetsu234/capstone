using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CharacterFM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Alignment { get; set; }
        public int Foreign { get; set; }
    }
}