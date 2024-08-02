using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OlympicMedalistBoard.BLL;
using OlympicMedalistBoard.Models;

namespace OlympicMedalistBoard.Controllers
{
    public class AthleteController : Controller
    {
        private readonly MedalService _medalService;
        private readonly SportService _sportService;
        private readonly CountryService _countryService;
        private readonly AthleteService _athleteService;
        public AthleteController(AthleteService athleteService, SportService sportService, CountryService countryService, MedalService medalService)
        {
            _athleteService = athleteService;
            _sportService = sportService;
            _countryService = countryService;
        }
        public IActionResult Index()
        {
            var athletes = _athleteService.GetAthletes();
            return View(athletes);
        }

        public IActionResult Create()
        {
            ViewBag.Sports = _sportService.GetSports();
            ViewBag.Countries = _countryService.GetCountries();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                athlete.Sport = _sportService.GetSport(athlete.SportID);
                athlete.Country = _countryService.GetCountry(athlete.CountryID);
                athlete.Medals = new List<Medal>();
                _athleteService.AddAthlete(athlete);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid data");
            ViewBag.Sports = _sportService.GetSports();
            ViewBag.Countries = _countryService.GetCountries();
            return View(athlete);
        }

        public IActionResult Edit(int id)
        {
            var athlete = _athleteService.GetAthleteById(id);
            ViewBag.Sports = _sportService.GetSports();
            ViewBag.Countries = _countryService.GetCountries();
            return View(athlete);
        }

        [HttpPost]
        public IActionResult Edit(Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                athlete.Sport = _sportService.GetSport(athlete.SportID);
                athlete.Country = _countryService.GetCountry(athlete.CountryID);
                _athleteService.UpdateAthlete(athlete);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid data");
            ViewBag.Sports = _sportService.GetSports();
            ViewBag.Countries = _countryService.GetCountries();
            return View(athlete);
        }

        public IActionResult Delete(int id)
        {
            var athlete = _athleteService.GetAthleteById(id);
            if(athlete != null)
            {
                _athleteService.DeleteAthlete(athlete);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Athlete not found");
            return RedirectToAction("Index");
        }

    }
}
