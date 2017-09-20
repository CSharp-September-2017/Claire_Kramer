using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dojodachi.Controllers {
    public class DojodachiController : Controller {
        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            if(Fullness == null) {
                Fullness = 20;
                HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            }
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            if(Happiness == null) {
                Happiness = 20;
                HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            }
            int? Energy = HttpContext.Session.GetInt32("Energy");
            if(Energy == null) {
                Energy = 50;
                HttpContext.Session.SetInt32("Energy", (int)Energy);
            }
            int? Meals = HttpContext.Session.GetInt32("Meals");
            if(Meals == null) {
                Meals = 3;
                HttpContext.Session.SetInt32("Meals", (int)Meals);
            }
            ViewBag.Fullness = Fullness;
            ViewBag.Happiness = Happiness;
            ViewBag.Energy = Energy;
            ViewBag.Meals = Meals;
            return View();
        }

        [HttpGet]
        [Route("Feed")]
        public IActionResult Feed() {
            Random random = new Random();
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            if(Meals == 0) {
                return RedirectToAction("Index");
            } 
            else {
                Meals -= 1;
                Fullness += random.Next(5,11);
                HttpContext.Session.SetInt32("Meals", (int)Meals);
                HttpContext.Session.SetInt32("Fullness", (int)Fullness);
                return RedirectToAction("Index");
            }
        }
    }
}