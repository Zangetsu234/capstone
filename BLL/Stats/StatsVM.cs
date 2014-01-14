using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StatsVM
    {
        public List<StatVM> Stats { get; set; }
        public StatsVM()
        {
            Stats = new List<StatVM>();
        }
    }
}