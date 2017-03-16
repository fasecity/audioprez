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
        /// <summary>
        /// this method is going to eventually display a music table to client it uses Random view
        /// </summary>
        /// <returns></returns>
        /// Authorize is made so evreyone has to log in
        [Authorize]
        public ActionResult Random()
        {
            //creating an instance of the database class
            ApplicationDbContext _context = new ApplicationDbContext();
            //making the variable into a list
            var music = _context.Musics.ToList();
            //the Path property inside Models.Path has to be exactly structured like : Path = "/Tunes/almost.mp3"
            //inorder to be passed into the view
           
            
           //returning the list
            return View(music);
            
        }
        /// <summary>
        /// This Method is going to add music into database it uses AddMusic view for forms
        /// </summary>
        /// <returns></returns>
        public ActionResult AddMusic()
        {
            return View();
        }
    }
}