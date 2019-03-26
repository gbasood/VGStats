using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VGStats.Controllers
{
    public class MatchController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

	    public IActionResult View(int id)
	    {
		    if (id == 0)
		    {
			    return RedirectToAction("List");
		    }
		    return View();
	    }

	    public IActionResult List(int startIndex, int pageSize)
	    {
		    return View();
	    }
    }
}