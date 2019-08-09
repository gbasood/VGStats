using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VGStats.Models;

namespace VGStats.Controllers
{
	public class HomeController : Controller
	{
        
        private readonly ModelDbContext db;

        public HomeController(ModelDbContext db)
        {
            this.db = db;
        }

        // TODO place inside view model
        public IActionResult Index()
		{
			//ViewBag.matchCount = 0;
			//ViewBag.nukedCount = 0;
			//ViewBag.explosionRatio = 0;
			//ViewBag.deathRatio = 0;
			//ViewBag.mapPlayrate = new List<(string, int)>
			//{
			//	("Test1", 10), ("Test2", 10)
			//};
			//// TODO get actual last match
			//using (db)
			//{
   //             ViewBag.lastMatch = db.Matches.Reverse().Take(1);
			//}
			return View(new IndexViewModel(db));
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
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
}
