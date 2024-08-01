using OlympicMedalistBoard.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlympicMedalistBoard.DAL {
	public class CountryDAL {
        private readonly OlympicMedalistBoardDbContext _context;

        public CountryDAL(OlympicMedalistBoardDbContext context) {
            _context = context;
        }

        public List<Country> GetCountries() {
            return _context.Countries.ToList();
        }
        public Country GetCountry(int id) {
            return _context.Countries.Find(id);
        }

        public void AddCountry(Country country) {
            _context.Countries.Add(country);
            _context.SaveChanges();
        }

        public void UpdateCountry(Country country) {
            _context.Countries.Update(country);
            _context.SaveChanges();
        }

        public void DeleteCountry(int id) {
            var country = _context.Countries.Find(id);
            if (country != null) {
                _context.Countries.Remove(country);
                _context.SaveChanges();
            }
        }
    }
}
