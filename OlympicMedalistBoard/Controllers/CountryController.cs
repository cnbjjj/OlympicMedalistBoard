using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlympicMedalistBoard.BLL;
using OlympicMedalistBoard.Models;

namespace OlympicMedalistBoard.Controllers {
	//[Authorize]
	public class CountryController : Controller {

		private readonly CountryService _countryService;
		public CountryController(CountryService countryService) {
			_countryService = countryService;
		}
		public IActionResult Index() {
			List<Country> countries = _countryService.GetCountries();
			return View(countries);
		}

		[HttpGet]
		public IActionResult Create() {
			return View();
		}

		[HttpPost]
		public IActionResult Create(CountryViewModel country) {
			if (ModelState.IsValid) {
				Country newCountry = new Country {
					CountryName = country.CountryName,
					CountryCode = country.CountryCode,
				};
				_countryService.AddCountry(newCountry);
				return RedirectToAction("Index");
			}
			return View(country);
		}

		[HttpGet]
		public IActionResult Update(int id) {
			var countryToEdit = _countryService.GetCountry(id);
			if (countryToEdit != null) {
				return View(countryToEdit);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Update(Country country) {
			if (ModelState.IsValid) {
				_countryService.UpdateCountry(country);
				return RedirectToAction("Index");
			}
			return View(country);
		}

		public IActionResult Delete(int id) {
			var country = _countryService.GetCountry(id);

			if (country != null) {
				return View(country);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult ConfirmDelete(int CountryID) {
			var country = _countryService.GetCountry(CountryID);

			if (country != null) {
				_countryService.DeleteCountry(CountryID);
				return RedirectToAction("Index");
			}
			return RedirectToAction("Index");
		}
	}
}
