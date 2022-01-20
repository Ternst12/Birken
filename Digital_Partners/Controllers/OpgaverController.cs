using Digital_Partners.data;
using Digital_Partners.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digital_Partners.Controllers
{
    public class OpgaverController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OpgaverController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Opgave> objList = _db.Opgaver;

            return View(objList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.Opgaver.Select(i => new SelectListItem
            {
                Text = i.Navn,
                Value = i.Id.ToString()
            }) ;

            ViewBag.TypeDropDown = TypeDropDown;

            Opgave test = new Opgave();
            return PartialView("_OpgavePartial", test);
        }
        //POST - Create
        [HttpPost]
        public IActionResult Create(Opgave obj)
        { 

            var MedarbejderMatch = _db.Medarbejdere.Where(i => i.Navn == obj.Medarbejder).FirstOrDefault();
            if(MedarbejderMatch == null)
            {
                return NotFound();
            } else if(MedarbejderMatch.Alder < obj.Min_alder)
            {
                return NotFound();
            }
            _db.Opgaver.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }





       

        // UPDATE - GET

        public IActionResult Update(int? Id)
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.Medarbejdere.Select(i => new SelectListItem
            {
                Text = i.Navn,
                Value = i.Navn
            });

            ViewBag.TypeDropDown = TypeDropDown;

            if (Id == null) //Validation
            {
                return NotFound();
            }
            var obj = _db.Opgaver.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // Update - Post
        [HttpPost]
        public IActionResult Update(Opgave obj)
        {
            var MedarbejderMatch = _db.Medarbejdere.Where(i => i.Navn == obj.Medarbejder).FirstOrDefault();
            if (MedarbejderMatch == null)
            {
                return RedirectToAction("Index");
            }
            else if (MedarbejderMatch.Alder < obj.Min_alder)
            {
                ViewBag.Error = "Medarbejderen er for ung";
                return RedirectToAction("Index");
            }
            
            _db.Opgaver.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
           
        }
    }
}
