using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// Easy enough right?  Hopefully the muscle-memory is building up after creating these smaller projects.
namespace callingcard.Controllers {
    public class UsersContoller : Controller {
        [HttpGet]
        [Route("{First}/{Last}/{Num}/{Color}")]
        public JsonResult Index(string First, string Last, int Num, string Color) {
            var AnonObject = new {
                FirstName = First,
                LastName = Last,
                Age = Num,
                FavoriteColor = Color
            };
            return Json(AnonObject);
        }
    }
}
