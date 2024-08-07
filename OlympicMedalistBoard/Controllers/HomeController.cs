using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OlympicMedalistBoard.DAL;
using OlympicMedalistBoard.Models;

namespace OlympicMedalistBoard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
	private readonly OlympicMedalistBoardDbContext _context;

	public HomeController(ILogger<HomeController> logger, OlympicMedalistBoardDbContext context)
    {
        _logger = logger;
		_context = context;
    }

	public IActionResult Index() {
		var countryMedalData = _context.Countries
			.Select(country => new HomeViewModel {
				CountryName = country.CountryName,
                CountryCode = country.CountryCode,
				GoldMedalCount = country.Athletes.SelectMany(a => a.Medals).Count(m => m.MedalType == "Gold"),
				SilverMedalCount = country.Athletes.SelectMany(a => a.Medals).Count(m => m.MedalType == "Silver"),
				BronzeMedalCount = country.Athletes.SelectMany(a => a.Medals).Count(m => m.MedalType == "Bronze"),
                TotalMedalCount = country.Athletes.SelectMany(a => a.Medals).Count()
            }).ToList();

		return View(countryMedalData);
	}

	public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
