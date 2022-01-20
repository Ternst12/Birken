using Digital_Partners.data;
using Digital_Partners.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Partners.Controllers
{
    public class MedarbejderController : Controller
    {

        private readonly ApplicationDbContext _db;

        public MedarbejderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Medarbejder> objList = _db.Medarbejdere;

            ViewBag.objList = objList;
            ViewBag.length = objList.Count();
            ViewBag.length1 = objList.Count() * 201;

            return View(objList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Medarbejder test = new Medarbejder();
            return PartialView("_MedarbejderPartial", test);
        }
        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Medarbejder obj)
        {
            
                _db.Medarbejdere.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // UPDATE - GET

        public IActionResult Update(int? Id)
        {
            if (Id == null) //Validation
            {
                return NotFound();
            }
            var obj = _db.Medarbejdere.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // Update - Post
        [HttpPost]
        public IActionResult Update(Medarbejder obj)
        {
            if (ModelState.IsValid) //Validation
            {
                _db.Medarbejdere.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
