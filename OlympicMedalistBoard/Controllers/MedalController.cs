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

        public async Task<IActionResult> Index()
        {
            var medals = await _medalService.GetAllMedalsAsync();
            return View(medals);
        }

        public async Task<IActionResult> Details(int id)
        {
            var medal = await _medalService.GetMedalByIdAsync(id);
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
        public async Task<IActionResult> Create(Medal medal)
        {
            if (ModelState.IsValid)
            {
                await _medalService.AddMedalAsync(medal);
                return RedirectToAction("Index");
            }
            return View(medal);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var medal = await _medalService.GetMedalByIdAsync(id);
            if (medal == null)
            {
                return NotFound();
            }
            return View(medal);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Medal medal)
        {
            if (id != medal.MedalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _medalService.UpdateMedalAsync(medal);
                return RedirectToAction("Index");
            }
            return View(medal);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var medal = await _medalService.GetMedalByIdAsync(id);
            if (medal == null)
            {
                return NotFound();
            }
            return View(medal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _medalService.DeleteMedalAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

