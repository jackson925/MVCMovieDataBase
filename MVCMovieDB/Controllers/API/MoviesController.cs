using AutoMapper;
using MVCMovieDB.DTOs;
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
        public IEnumerable<MovieDTO> GetMovies()
        {
           return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }
        //GET /api/movies/1
        public MovieDTO GetMovie(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Movie, MovieDTO>(movie);            
        }
        //POST /api/movies/
        [HttpPost]
        public MovieDTO CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDTO.Id = movie.Id;
            return movieDTO;
        }
        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            var movieInDB = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDTO, movieInDB);
      
            _context.SaveChanges();
        }
        //DELETE /api/movies/1
        [HttpDelete]
        public void Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movie);

            _context.SaveChanges();
        }

    }
}
