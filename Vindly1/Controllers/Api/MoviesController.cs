using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vindly1.Models;

namespace Vindly1.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private readonly  ApplicationDbContext _context;


        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //Get/api/movies
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
           return _context.Movies.ToList();
        }

        //Get/api/movies/id
        [HttpGet]
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return (movie);
        }
        //Post/api/movies
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)

             throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Add(movie);
            _context.SaveChanges();
             return movie;
        }
        //PUT/api/movies/id
        [HttpPut]
        public void UpdateMovie(int id,Movie movie)
        {
            if (!ModelState.IsValid)
             throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movieInDb == null)
             throw new HttpResponseException(HttpStatusCode.NotFound);

            movieInDb.Name = movie.Name;
            movieInDb.IsRental = movie.IsRental;
            movieInDb.CustomerId = movie.CustomerId;
            _context.SaveChanges();
        }
        //Delete/api/movie/id
        [HttpDelete]

        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
