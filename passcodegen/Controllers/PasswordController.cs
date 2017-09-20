using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace passcodegen.Controllers {
    public class PasswordController : Controller {
        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            int? Count = HttpContext.Session.GetInt32("Count");
            if(Count == null) {
                Count = 0;
            }
            Count += 1;
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string result = "";
            for (int i = 0; i < 14; i++) {
                result = result + characters[random.Next(characters.Length)];
            }
            ViewBag.Password = result;
            ViewBag.Count = Count;
            HttpContext.Session.SetInt32("Count", (int)Count);
            return View();
        }
    }
}