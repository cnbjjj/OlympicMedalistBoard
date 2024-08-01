using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Authorization;
using OlympicMedalistBoard.Models;
using OlympicMedalistBoard.BLL;
using Microsoft.AspNetCore.Authorization;

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
            var sports = _sportService.GetSports();
            return View(sports);
        }

        public IActionResult Create()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(Sport sport)
        {
            if (ModelState.IsValid)
            {
                _sportService.AddSport(sport);
                return RedirectToAction("Index");
            }
            return View(sport);  
        }
    }
}
