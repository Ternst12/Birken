using Digital_Partners.data;
using Digital_Partners.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Partners.Controllers
{
    public class HomeController : Controller
    {


        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var objListMedarbejdere = _db.Medarbejdere;
            var objListOpgaver = _db.Opgaver;
            ViewBag.length = objListMedarbejdere.Count();
            ViewBag.length1 = objListOpgaver.Count();

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
