using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace pokeinfo {
    public class PokeController : Controller {
        [HttpGet]
        [Route("pokemon/{pokeid}")]
        public IActionResult GetPokemon(int pokeid) {
            var PokeObject = new Pokemon();

            WebRequest.GetPokemonDataAsync(pokeid, PokeResponse => {
                PokeObject = PokeResponse;
            }).Wait();
            ViewBag.Pokemon = PokeObject;
            return View();
        }
    }
}