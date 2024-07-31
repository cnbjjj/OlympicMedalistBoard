using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicMedalistBoard.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public ICollection<Athlete> Athletes { get; set; }
    }
}
