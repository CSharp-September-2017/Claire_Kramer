using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dojosurvey.Controllers {
    public class SurveyController : Controller {
        [HttpGet]
        [Route("index")]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        [Route("result")]
        public IActionResult Result(string Name, string Location, string Language, string Comment) {
            ViewBag.Name = Name;
            ViewBag.Location = Location;
            ViewBag.Language = Language;
            ViewBag.Comment = Comment;
            return View();
        }
    }
}