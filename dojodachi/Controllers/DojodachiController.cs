using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace dojodachi.Controllers {
    public class DojodachiController : Controller {
        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            if(HttpContext.Session.GetInt32("Fullness") == null) {
                int Fullness = 20;
                HttpContext.Session.SetInt32("Fullness", Fullness);
            }
            if(HttpContext.Session.GetInt32("Happiness") == null) {
                int Happiness = 20;
                HttpContext.Session.SetInt32("Happiness", Happiness);
            }
            if(HttpContext.Session.GetInt32("Energy") == null) {
                int Energy = 50;
                HttpContext.Session.SetInt32("Energy", Energy);
            }
            if(HttpContext.Session.GetInt32("Meals") == null) {
                int Meals = 3;
                HttpContext.Session.SetInt32("Meals", Meals);
            }
            if(HttpContext.Session.GetString("Mood") == null) {
                HttpContext.Session.SetString("Mood", "Normal");
            }
            if (HttpContext.Session.GetInt32("Fullness") > 99 && HttpContext.Session.GetInt32("Happiness") > 99 && HttpContext.Session.GetInt32("Energy") > 99) {
                HttpContext.Session.SetString("Message", "You Win!");
                HttpContext.Session.SetString("Status", "Done");
                HttpContext.Session.SetString("Mood", "Normal");
            }
            else {
                HttpContext.Session.SetString("Status", "Play");
            }
            string[] Keys = new string[] {"Fullness", "Happiness"};
            foreach (string key in Keys) {
                if(HttpContext.Session.GetInt32((string)key) == 0) {
                    HttpContext.Session.SetString("Message", "Your Dojodachi Died...");
                    HttpContext.Session.SetString("Status", "Done");
                    HttpContext.Session.SetString("Mood", "Sad");
                }
            }
            ViewBag.Fullness = HttpContext.Session.GetInt32("Fullness");
            ViewBag.Happiness = HttpContext.Session.GetInt32("Happiness");
            ViewBag.Energy = HttpContext.Session.GetInt32("Energy");
            ViewBag.Meals = HttpContext.Session.GetInt32("Meals");
            ViewBag.Message = HttpContext.Session.GetString("Message");
            ViewBag.Status = HttpContext.Session.GetString("Status");
            ViewBag.Mood = HttpContext.Session.GetString("Mood");
            return View();
        }

        [HttpGet]
        [Route("Feed")]
        public IActionResult Feed() {
            Random random = new Random();
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            if(Meals == 0) {
                HttpContext.Session.SetString("Mood", "Sad");
                HttpContext.Session.SetString("Message", "No Meals to Feed Dojodachi");
                return RedirectToAction("Index");
            } 
            else {
                Meals -= 1;
                HttpContext.Session.SetInt32("Meals", (int)Meals);
                if (random.Next(0,4) > 0) {
                    Fullness += random.Next(5,11);
                    HttpContext.Session.SetString("Mood", "Normal");
                    HttpContext.Session.SetInt32("Fullness", (int)Fullness);
                    HttpContext.Session.SetString("Message", "Fed Your Dojodachi");
                }
                else {
                    HttpContext.Session.SetString("Mood", "Sad");
                    HttpContext.Session.SetString("Message", "Your Dojodachi didn't like the meal...");
                }
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("Play")]
        public IActionResult Play() {
            Random random = new Random();
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            if (Energy < 5) {
                HttpContext.Session.SetString("Mood", "Sad");
                HttpContext.Session.SetString("Message", "Not Enough Energy");
                return RedirectToAction("Index");
            }
            Energy -= 5;
            HttpContext.Session.SetInt32("Energy", (int)Energy);
            if(random.Next(0,4) > 0) {
                Happiness += random.Next(5,11);
                HttpContext.Session.SetString("Mood", "Play");
                HttpContext.Session.SetInt32("Happiness", (int)Happiness);
                HttpContext.Session.SetString("Message", "Your Dojodachi's Happiness Improved!");
            }
            else {
                HttpContext.Session.SetString("Mood", "Sad");
                HttpContext.Session.SetString("Message", "Looks like Your Dojodachi didn't want to play...");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Work")]
        public IActionResult Work() {
            Random random = new Random();
            int? Energy = HttpContext.Session.GetInt32("Energy");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            if (Energy < 5) {
                HttpContext.Session.SetString("Mood", "Sad");
                HttpContext.Session.SetString("Message", "Not Enough Energy");
                return RedirectToAction("Index");
            }
            Energy -= 5;
            Meals += random.Next(1,4);
            HttpContext.Session.SetInt32("Energy", (int)Energy);
            HttpContext.Session.SetInt32("Meals", (int)Meals);
            HttpContext.Session.SetString("Message", "Your Dojodachi is Hard Working!");
            HttpContext.Session.SetString("Mood", "Normal");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Sleep")]
        public IActionResult Sleep() {
            int? Energy = HttpContext.Session.GetInt32("Energy");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            Energy += 15;
            HttpContext.Session.SetInt32("Energy", (int)Energy);
            if (Fullness < 5) {
                HttpContext.Session.SetString("Mood", "Sad");
                HttpContext.Session.SetString("Message", "Your Dojodachi is Hungry");
                return RedirectToAction("Index");
            }
            if (Happiness < 5) {
                HttpContext.Session.SetString("Mood", "Sad");
                HttpContext.Session.SetString("Message", "Your Dojodachi is Unhappy");
                return RedirectToAction("Index");
            }
            Fullness -= 5;
            Happiness -= 5;
            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            HttpContext.Session.SetString("Message", "Your Dojodachi is Sleeping. Shhhh...");
            HttpContext.Session.SetString("Mood", "Normal");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Reset")]
        public IActionResult Reset() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}