using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;**-
using OlympicMedalistBoard.Models;
using OlympicMedalistBoard.BLL;


namespace OlympicMedalistBoard.Controllers
{
    public class SportController : Controller
    {
        //[Authorize]
        private readonly SportService _sportService;

        public SportController (SportService sportService)
        {
            _sportService = sportService;
        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            List<Sport> sports = _sportService.GetSports();
            return View(sports);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Create(SportViewModel sportViewModel)
        {
            if (ModelState.IsValid)
            {
                Sport newSport = new Sport()
                {
                    SportName = sportViewModel.SportName,
                };
                _sportService.AddSport(newSport);
                return RedirectToAction("Index");
            }
            return View(sportViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Sport sport = _sportService.GetSport(id);
            if (sport != null)
            {
                return View(new SportViewModel { SportID = sport.SportID, SportName = sport.SportName });
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(SportViewModel sportViewModel)
        {
            if (ModelState.IsValid)
            {
                Sport newSport = new Sport()
                {
                    SportID = sportViewModel.SportID,
                    SportName = sportViewModel.SportName
                };
                _sportService.UpdateSport(newSport);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Sport sport  = _sportService.GetSport(id);
            _sportService.DeleteSport(sport.SportID);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int SportID)
        {
            Sport sport = _sportService.GetSport(SportID);

            if (sport != null)
            {
                _sportService.DeleteSport(sport.SportID);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
