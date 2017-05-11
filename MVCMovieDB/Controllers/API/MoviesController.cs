using MVCMovieDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCMovieDB.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/movies
        public IEnumerable<Movie> GetMovies()
        {
            var movies = _context.Movies.ToList();

            return movies;
        }
        //GET /api/movies/1
        public Movie GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return movie;            
        }
        //POST /api/movies/
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }
        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movieInDB.Name = movie.Name;
            movieInDB.Genre = movie.Genre;
            movieInDB.ReleaseDate = movie.ReleaseDate;
            movieInDB.DateAdded = movie.DateAdded;

            _context.SaveChanges();
        }
        //DELETE /api/movies/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movie);

            _context.SaveChanges();
        }

    }
}
