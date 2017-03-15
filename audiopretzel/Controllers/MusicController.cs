using audiopretzel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace audiopretzel.Controllers
{
    public class MusicController : Controller
    {
        // GET: Music/Random
        public ActionResult Random()
        {
            //the Path property inside Models.Path has to be exactly structured like : Path = "/Tunes/almost.mp3"
            //inorder to be passed into the view
            var music = new Music() { Name = "almost",Artist = "fasecity", Genre = "electronic",Path = "/Tunes/almost.mp3" };
            return View(music);
        }
    }
}