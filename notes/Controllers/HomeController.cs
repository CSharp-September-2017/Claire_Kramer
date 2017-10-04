using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using notes.Models;
using notes.Factories;

namespace notes.Controllers
{
    public class HomeController : Controller
    {
        private readonly NoteFactory _noteFactory;
        public HomeController(NoteFactory noteFactory) {
            _noteFactory = noteFactory;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        [Route("notes")]
        public JsonResult AllNotes() {
            List<Note> AllNotes = _noteFactory.FindAll();
            return Json(AllNotes);
        }

        [HttpPost]
        [Route("newnote")]
        public JsonResult CreateNote(Note model) {
            if(ModelState.IsValid) {
                _noteFactory.Add(model);
                Note NewNote = _noteFactory.GetLatest();
                return Json(NewNote);
            }
            return Json(new {Failed = "true"});
        }

        [HttpPost]
        [Route("updatenote")]
        public void UpdateNote(Note model) {
            _noteFactory.Update(model);
        }

        [HttpPost]
        [Route("deletenote/{id}")]
        public void DeleteNote(int Id) {
            _noteFactory.Delete(Id);
        }
    }
}
