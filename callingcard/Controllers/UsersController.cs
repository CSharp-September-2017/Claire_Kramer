using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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