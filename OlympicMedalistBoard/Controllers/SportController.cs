using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
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
        [HttpPost]
        public IActionResult Create(Sport sport)
        {
            if (ModelState.IsValid)
            {
                Sport newSport = new Sport()
                {
                    SportName = sport.SportName,
                };
                _sportService.AddSport(newSport);
                return RedirectToAction("Index");
            }
            return View(sport);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var sportToEdit = _sportService.GetSport(id);
            if (sportToEdit != null)
            {
                return View(sportToEdit);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Sport sport)
        {
            if (ModelState.IsValid)
            {
                _sportService.UpdateSport(sport);
                return RedirectToAction("Index");
            }
            return View(sport);
        }

        public IActionResult Delete(int id)
        {
            var sport  = _sportService.GetSport(id);
            
            if (sport != null)
            {
                return View(sport);
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int SportID)
        {
            var sport = _sportService.GetSport(SportID);

            if (sport != null)
            {
                _sportService.DeleteSport(SportID);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
