using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicMedalistBoard.Models
{
    public class Sport
    {
        public int SportID { get; set; }
        public string SportName { get; set; }

        public ICollection<Athlete> Athletes { get; set; }
        public ICollection<Medal> Medals { get; set; }
    }
}
