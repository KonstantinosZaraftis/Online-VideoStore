using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vindly1.Models;
using Vindly1.ViewModel;

namespace Vindly1.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Customer).ToList();
            return View(movies);

        }




        public ActionResult NewMovie()
        {
            var customers = _context.Customers.ToList();

            var viewModel = new CustomerMovieViewModel
            {
                Customers = customers
            };
            return View(viewModel);

        }

        //public ActionResult CreateNewMovie()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult CreateNewMovie([Bind(Include = "Name,IsRental,CustomerId")] Movie movie)
        {
            if (ModelState.IsValid)
                _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        public ActionResult Edit(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerMovieViewModel()
            {
                Movie = movie,
                Customers = _context.Customers.ToList()

            };
            return View(viewModel);

        }
        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)

            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
             return  RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var movie = _context.Movies.Include(c => c.Customer).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }


    }
}
    
