using Microsoft.AspNetCore.Mvc;
using OlympicMedalistBoard.BLL;
using OlympicMedalistBoard.Models;

namespace OlympicMedalistBoard.Controllers
{
    public class AthleteController : Controller
    {
        private readonly AthleteService _athleteService;
        public AthleteController(AthleteService athleteService)
        {
            _athleteService = athleteService;
        }
        public IActionResult Index()
        {
            var athletes = _athleteService.GetAthletes();
            return View(athletes);
        }
    }
}
