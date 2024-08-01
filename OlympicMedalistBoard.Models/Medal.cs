using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicMedalistBoard.Models
{
    public class Medal
    {
        public int MedalID { get; set; }
        public int AthleteID { get; set; }
        public int SportID { get; set; }
        public string MedalType { get; set; }
        public DateTime DateAwarded { get; set; }
        public Athlete? Athlete { get; set; }
        public Sport? Sport { get; set; }
    }
}
