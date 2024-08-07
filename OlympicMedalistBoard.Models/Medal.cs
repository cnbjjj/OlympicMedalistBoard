using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicMedalistBoard.Models
{
    public class Medal
    {
        public int MedalID { get; set; }

        [Required(ErrorMessage = "Athlete is needed")]
        public int AthleteID { get; set; }

        [Required(ErrorMessage = "Sport is needed")]
        public int SportID { get; set; }

        [Required(ErrorMessage = "Medal is needed")]
        public string MedalType { get; set; }

        [Required(ErrorMessage = "Date is needed")]
        public DateTime DateAwarded { get; set; }
        public Athlete? Athlete { get; set; }
        public Sport? Sport { get; set; }
    }
}
