using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlympicMedalistBoard.DAL;
using OlympicMedalistBoard.Models;

namespace OlympicMedalistBoard.BLL {
	public class CountryService {
        private readonly CountryDAL _countryDal;
        private readonly MedalService _medalService;
        private readonly AthleteService _athleteService;

        public CountryService(CountryDAL countryDal, MedalService medalService, AthleteService athleteService) {
            _countryDal = countryDal;
            _medalService = medalService;
            _athleteService = athleteService;
        }

        public List<Country> GetCountries() {
            return _countryDal.GetCountries();
        }

        public Country GetCountry(int id) {
            return _countryDal.GetCountry(id);
        }

        public void AddCountry(Country country) {
            _countryDal.AddCountry(country);
        }

        public void UpdateCountry(Country country) {
            _countryDal.UpdateCountry(country);
        }

        public void DeleteCountry(int id) {
            _medalService.DeleteMedalsByCountryId(id);
            _athleteService.DeleteAthletesByCountryId(id);
            _countryDal.DeleteCountry(id);
        }
    }
}
