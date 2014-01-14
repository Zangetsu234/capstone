using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class StatService
    {
        public StatsVM GetUsers()
        {
            StatisticsDAO dao = new StatisticsDAO();
            List<Statistics> stats = dao.GetAllStats();
            StatsVM statsVM = new StatsVM();
            foreach (Statistics stat in stats)
            {
                StatVM statVM = new StatVM();
                statVM.ID = stat.ID;
                statVM.Strength = stat.Strength;
                statVM.Intelligence = stat.Intelligence;
                statVM.Dexterity = stat.Dexterity;
                statsVM.Stats.Add(statVM);
            }
            return statsVM;
        }
        public bool CreateStats(StatFM statFM)
        {
            StatisticsDAO dao = new StatisticsDAO();
            Statistics stat = new Statistics();
            stat.Strength = statFM.Strength;
            stat.Intelligence = statFM.Intelligence;
            stat.Dexterity = statFM.Dexterity;
            stat.Foreign = statFM.Foreign;
            dao.CreateStats(stat);
            return true;
        }
    }
}