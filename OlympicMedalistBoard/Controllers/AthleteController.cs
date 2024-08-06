using Microsoft.AspNetCore.Mvc;
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
            _medalService = medalService;
        }
        public IActionResult Index()
        {
            var athletes = _athleteService.GetAthletes();
            var athleteViewModels = athletes.Select(a => new AthleteViewModel
            {
                CountryID = a.CountryID,
                SportID = a.SportID,
                AthleteID = a.AthleteID,
                Name = a.Name,
                Birthdate = a.Birthdate,
                Country = a.Country,
                Sport = a.Sport,
                PhotoPath = GetPhotoPath(a.AthleteID, a.Name)
            }).ToList();

            return View(athleteViewModels);
        }

        public IActionResult Create()
        {
            ViewBag.WebPath =
            ViewBag.Sports = _sportService.GetSports();
            ViewBag.Countries = _countryService.GetCountries();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Athlete athlete, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                Athlete newAthlete = _athleteService.AddAthlete(athlete);
                Upload(photo, $"{newAthlete.AthleteID}-{newAthlete.Name}.jpg");
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
            var avm = new AthleteViewModel
            {
                CountryID = athlete.CountryID,
                SportID = athlete.SportID,
                AthleteID = athlete.AthleteID,
                Name = athlete.Name,
                Birthdate = athlete.Birthdate,
                Country = athlete.Country,
                Sport = athlete.Sport,
                PhotoPath = GetPhotoPath(athlete.AthleteID, athlete.Name)
            };
            return View(avm);
        }

        [HttpPost]
        public IActionResult Edit(Athlete athlete, IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                Athlete newAthlete = _athleteService.UpdateAthlete(athlete);
                Upload(photo, $"{newAthlete.AthleteID}-{newAthlete.Name}.jpg");
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
            if (athlete != null)
            {
                _athleteService.DeleteAthlete(athlete);
                RemovePhoto(athlete.AthleteID,athlete.Name);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Athlete not found");
            return RedirectToAction("Index");
        }

        private string Upload(IFormFile file, string name)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", name);
            if (file != null && file.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return path;
            }
            return string.Empty;
        }

        private static void RemovePhoto(int athleteId, string name)
        {
            var photo = $"{athleteId}-{name}.jpg";
            var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", photo);
            System.IO.File.Delete(photoPath);
        }

        private static string GetPhotoPath(int athleteId, string name)
        {   
            var photo = $"{athleteId}-{name}.jpg";
            var photoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", photo);
            if (System.IO.File.Exists(photoPath))
            {
                return $"/img/{photo}";
            }
            else
            {
                Console.WriteLine($"File not found: {photoPath}");
                return "/img/Athlete.jpg";
            }
        }

    }
}
