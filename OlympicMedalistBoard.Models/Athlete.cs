using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicMedalistBoard.Models
{
    public class Athlete
    {
        public int AthleteID { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public int SportID { get; set; }
        public DateTime Birthdate { get; set; }
        public Country? Country { get; set; }
        public Sport? Sport { get; set; }
        public ICollection<Medal>? Medals { get; set; }
    }
}
