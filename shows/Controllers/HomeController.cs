using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using shows.Models;

namespace shows.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("add_show")]
        public IActionResult AddShow(string Title, string Network, string Description) {
            Show newShow = new Show{
                Title = Title,
                Network = Network,
                Description = Description,
            };
        }
    }
}
