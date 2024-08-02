using Microsoft.AspNetCore.Mvc;
using OlympicMedalistBoard.BLL;
using OlympicMedalistBoard.Models;
using Microsoft.AspNetCore.Authorization;

namespace OlympicMedalistBoard.Controllers
{
    //[Authorize] 
    public class MedalController : Controller
    {
        private readonly MedalService _medalService;

        public MedalController(MedalService medalService)
        {
            _medalService = medalService;
        }

        public IActionResult Index()
        {
            var medals = _medalService.GetAllMedals();
            return View(medals);
        }

        public IActionResult Details(int id)
        {
            var medal = _medalService.GetMedalById(id);
            if (medal == null)
            {
                return NotFound();
            }
            return View(medal);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Medal medal)
        {
            if (ModelState.IsValid)
            {
                _medalService.AddMedal(medal);
                return RedirectToAction("Index");
            }
            return View(medal);
        }

        public IActionResult Edit(int id)
        {
            var medal = _medalService.GetMedalById(id);
            if (medal == null)
            {
                return NotFound();
            }
            return View(medal);
        }

        [HttpPost]
        public IActionResult Edit(int id, Medal medal)
        {
            if (id != medal.MedalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _medalService.UpdateMedal(medal);
                return RedirectToAction("Index");
            }
            return View(medal);
        }

        public IActionResult Delete(int id)
        {
            var medal = _medalService.GetMedalById(id);
            if (medal == null)
            {
                return NotFound();
            }
            return View(medal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _medalService.DeleteMedal(id);
            return RedirectToAction(nameof(Index));
        }
    }
}


