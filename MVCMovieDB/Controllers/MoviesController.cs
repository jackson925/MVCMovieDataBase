using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCMovieDB.Models;


namespace MVCMovieDB.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult MoviesList()
        {

            var movies = _context.Movies.ToList();

            return View(movies);
        }
        public ActionResult MovieDetails(Movie movie)
        {
            if(movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }
    }
}
    
