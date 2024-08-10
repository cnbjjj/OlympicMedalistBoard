using Microsoft.AspNetCore.Mvc;
using OlympicMedalistBoard.BLL;
using OlympicMedalistBoard.Models;
using Microsoft.AspNetCore.Authorization;

namespace OlympicMedalistBoard.Controllers
{
    [Authorize]
    public class MedalController : Controller
    {
        private readonly MedalService _medalService;
        private readonly SportService _sportService;
        private readonly CountryService _countryService;
        private readonly AthleteService _athleteService;

        public MedalController(MedalService medalService, SportService sportService, CountryService countryService, AthleteService athleteService)
        {
            _medalService = medalService;
            _sportService = sportService;
            _countryService = countryService;
            _athleteService = athleteService;
        }

        public IActionResult Index()
        {
            var medals = _medalService.GetAllMedals();
            return View(medals);
        }

        [Authorize] 
        public IActionResult Details(int id)
        {
            var medal = _medalService.GetMedalById(id);
            if (medal == null)
            {
                return NotFound();
            }
            return View(medal);
        }

        [Authorize] 
        public IActionResult Create()
        {
            ViewBag.Sports = _sportService.GetSports();
            ViewBag.Countries = _countryService.GetCountries();
            ViewBag.Athletes = _athleteService.GetAthletes();
            return View();
        }

        [Authorize] 
        [HttpPost]
        public IActionResult Create(Medal medal)
        {
            if (ModelState.IsValid)
            {
                _medalService.AddMedal(medal);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid data");
            ViewBag.Sports = _sportService.GetSports();
            ViewBag.Athlete = _athleteService.GetAthletes();
            return View(medal);
        }

        [Authorize] 
        public IActionResult Edit(int id)
        {
            var medal = _medalService.GetMedalById(id);
            ViewBag.Sports = _sportService.GetSports();
            ViewBag.Athlete = _athleteService.GetAthletes();
            return View(medal);
        }

        [Authorize] 
        [HttpPost]
        public IActionResult Edit(int id, Medal medal)
        {
            if (ModelState.IsValid)
            {
                medal.Sport = _sportService.GetSport(medal.SportID);
                medal.Athlete = _athleteService.GetAthleteById(medal.AthleteID);
                _medalService.UpdateMedal(medal);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Invalid data");
            ViewBag.Sports = _sportService.GetSports();
            ViewBag.Athlete = _athleteService.GetAthletes();
            return View(medal);
        }

        [Authorize] 
        public IActionResult Delete(int id)
        {
            var medal = _medalService.GetMedalById(id);
            if (medal == null)
            {
                return NotFound();
            }
            return View(medal);
        }

        [Authorize] 
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _medalService.DeleteMedal(id);
            return RedirectToAction(nameof(Index));
        }
    }
}