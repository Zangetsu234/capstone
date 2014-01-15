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
        public StatVM ConvertStat(Statistics stat)
        {
            StatVM statVM = new StatVM();
            statVM.ID = stat.ID;
            statVM.Strength = stat.Strength;
            statVM.Intelligence = stat.Intelligence;
            statVM.Dexterity = stat.Dexterity;
            statVM.Foreign = stat.Foreign;
            return statVM;
        }
        public Statistics ConvertStat(StatVM statVM)
        {
            Statistics stat = new Statistics();
            statVM.ID = stat.ID;
            statVM.Strength = stat.Strength;
            statVM.Intelligence = stat.Intelligence;
            statVM.Dexterity = stat.Dexterity;
            statVM.Foreign = stat.Foreign;
            return stat;
        }
        public List<StatVM> GetCharacterStats(int c_id)
        {
            List<StatVM> statsVM = new List<StatVM>();
            StatisticsDAO dao = new StatisticsDAO();
            List<Statistics> stats = dao.GetCharacterStats(c_id);
            foreach (Statistics stat in stats)
            {
                statsVM.Add(ConvertStat(stat));
            }
            return statsVM;
        }
    }
}