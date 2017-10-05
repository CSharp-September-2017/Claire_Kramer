using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using movie_api.Models;

namespace movie_api.Controllers
{
    public class MovieController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            var AllMovies = DbConnector.Query("SELECT * FROM Movies ORDER BY Created_at DESC");
            ViewBag.AllMovies = AllMovies;
            return View();
        }

        [HttpPost]
        [Route("movie/{title}")]
        public IActionResult GetMovie(string title) {
            var MovieInfo = new Dictionary<string, object>();
            WebRequest.GetMovieInfo(title, ApiResponse =>
            {
                MovieInfo = ApiResponse;
            }).Wait();
            var MovieTitle = MovieInfo["title"];
            var Rating = MovieInfo["vote_average"];
            var ReleaseYear = MovieInfo["release_date"];
            string query = $"INSERT INTO movies (Title, Rating, Release_year, Created_at, Updated_at) VALUES('{MovieTitle}', '{Rating}', '{ReleaseYear}', NOW(), NOW())";
            DbConnector.Execute(query);
            return RedirectToAction("Index");
        }
    }
}
