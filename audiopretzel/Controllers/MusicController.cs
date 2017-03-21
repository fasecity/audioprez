using audiopretzel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace audiopretzel.Controllers
{
    public class MusicController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Music/Random
        /// <summary>
        /// this method is going to eventually display a music table to client it uses Random view
        /// </summary>
        /// <returns></returns>
        /// Authorize is made so evreyone has to log in
        [Authorize]
        public ActionResult Random(string sortOrder, string searchString)
        {
            //creating an instance of the database class
            // ApplicationDbContext _context = new ApplicationDbContext();
            //making the variable into a list
            var music = _context.Musics.ToList();
            //the Path property inside Models.Path has to be exactly structured like : Path = "/Tunes/almost.mp3"
            //inorder to be passed into the view

            //linq sort I made a viewbag called nameSort and made a string param called sortOrder
            //created a linq expression with decending features that defaults to accending
            //the thing is inorder for it to work it uses the sortMusic evreywhere since duh its the linq query
            ViewBag.nameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.artistSort = String.IsNullOrEmpty(sortOrder) ? "artist_desc" : "";
            ViewBag.genreSort = String.IsNullOrEmpty(sortOrder) ? "genre_desc" : "";
            var sortMusic = from m in music select m;
            //This is literally the search funtion right here its using the searchString Param in controller
            //and its checking if its null or empty then using the linq expression
            //it searches where m is genre,artist and name thats it!!!
            if (!String.IsNullOrEmpty(searchString))
            {
                sortMusic = sortMusic.Where(m => m.Genre.Contains(searchString)
                                       || m.Artist.Contains(searchString) || m.Name.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    sortMusic = sortMusic.OrderByDescending(m => m.Name);
                    break;

                case "artist_desc":
                    sortMusic = sortMusic.OrderByDescending(m => m.Artist);
                    break;

                case "genre_desc":
                    sortMusic = sortMusic.OrderByDescending(m => m.Genre);
                    break;


                default:
                    sortMusic = sortMusic.OrderBy(m => m.Name);
                    break;
            }
            //returning the list
            return View(sortMusic.ToList());

        }
        /// <summary>
        /// This Method is going to add music into database it uses AddMusic view for forms
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public ActionResult AddMusic()
        {
            // ApplicationDbContext _context = new ApplicationDbContext();
            //making the variable into a list
            //var music1 = new Music { Name = "test", Genre = "test" , Artist="test", Path= "https://w.soundcloud.com/player/?url=https%3A//api.soundcloud.com/tracks/177633813&amp;color=ff5500&amp;auto_play=false&amp;hide_related=false&amp;show_comments=true&amp;show_user=true&amp;show_reposts=false" };
            //ViewBag.name = music1.Name;
            //ViewBag.artist = music1.Artist;
            //ViewBag.genre = music1.Genre;
            //ViewBag.path = music1.Path;
            //ApplicationDbContext _context = new ApplicationDbContext();
           // var music = _context.Musics;


            
            return View();
        }
        //use authorize and http post gets the methof from form
        [Authorize]
        [HttpPost]
        public ActionResult AddMusic(Music model)
        {

            try
            {
                //intantiate database
                ApplicationDbContext db = new ApplicationDbContext();
                //instantiate Music class
                Music musicAdder = new Music();
                //add properties from music class and bind them to the view variables
                musicAdder.Artist = model.Artist;
                musicAdder.Genre = model.Genre;
                musicAdder.Name = model.Name;
                musicAdder.Path = model.Path;
                //add object to database
                db.Musics.Add(musicAdder);
                //save changes
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


           // return RedirectToAction("/Music/Random");
             return View();
        }
    }
}