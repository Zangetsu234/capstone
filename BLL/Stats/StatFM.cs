using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class StatFM
    {
        public int ID { get; set; }
        public string Strength { get; set; }
        public string Intelligence { get; set; }
        public string Dexterity { get; set; }
        public int Foreign { get; set; }
        public StatFM(Statistics stat)
        {
            this.ID = stat.ID;
            this.Strength = stat.Strength;
            this.Intelligence = stat.Intelligence;
            this.Dexterity = stat.Dexterity;
            this.Foreign = stat.Foreign;
        }
        public StatFM()
        {

        }
    }
}