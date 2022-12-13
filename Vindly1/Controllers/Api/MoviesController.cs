using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vindly1.Dtos;
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
        public IEnumerable<MovieDto> GetMovies()
        {
           return _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
        }

        //Get/api/movies/id
        [HttpGet]
        public MovieDto GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Movie,MovieDto>(movie);
        }
        //Post/api/movies
        [HttpPost]
        public MovieDto CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return movieDto;
        }
        //PUT/api/movies/id
        [HttpPut]
        public void UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
             throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);
            
            if (movieInDb == null)
             throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            //movieInDb.Name = movie.Name;
            //movieInDb.IsRental = movie.IsRental;
            //movieInDb.CustomerId = movie.CustomerId;
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
