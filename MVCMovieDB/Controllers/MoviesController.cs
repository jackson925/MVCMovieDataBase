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
        public ActionResult New()
        {
            var movie = new Movie();
            return View("MovieForm", movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
           
            if(!ModelState.IsValid)
            {
                var movief = new Movie();
                return View("movieForm", movie);
            }

            if(movie.Id == 0) 
            _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.Genre = movie.Genre;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Stock = movie.Stock;
                movieInDb.Id = movie.Id;
            }
            _context.SaveChanges();
            

            return RedirectToAction("MoviesList", "Movies");
        }


        public ActionResult Edit(Movie movie)
        {
          
               if (movie == null)
                return HttpNotFound();


            return View("MovieForm", movie);
        }
    }
}
    
