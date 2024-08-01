using Microsoft.AspNetCore.Mvc;
using OlympicMedalistBoard.BLL;
using OlympicMedalistBoard.Models;

namespace OlympicMedalistBoard.Controllers {
	public class CountryController : Controller {

		private readonly CountryService _countryService;
		public CountryController(CountryService countryService) {
			_countryService = countryService;
		}
		public IActionResult Index() {
			List<Country> countries = _countryService.GetCountries();
			return View(countries);
		}
	}
}
