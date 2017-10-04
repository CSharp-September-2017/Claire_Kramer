using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbConnection;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace quoting.Controllers {
    public class QuoteController : Controller {
        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        [Route("submit")]
        public IActionResult SubmitQuote(string Name, string Quote) {
            DbConnector.Execute($"INSERT INTO quotes (name, quote, createdAt, updatedAt) VALUES ('{Name}', '{Quote}', NOW(), NOW())");
            return RedirectToAction("ShowQuotes");
        }

        [HttpGet]
        [Route("Quotes")]
        public IActionResult ShowQuotes() {
            var AllQuotes = DbConnector.Query("SELECT * FROM quotes ORDER BY createdAt DESC");
            ViewBag.AllQuotes = AllQuotes;
            return View();
        }
    }
}