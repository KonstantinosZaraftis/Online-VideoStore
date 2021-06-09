using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vindly1.Models;
using Vindly1.ViewModel;

namespace Vindly1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "top Gun" };


            var customer = new List<Customer>() {
                            new Customer(){  Name="Bill"},
                            new Customer(){  Name="Steve"},
                            new Customer(){  Name="Ram"},
                            new Customer(){  Name="Abdul"}
                        };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customer
            };


            return View(viewModel);//otan to bazoume sto view ousiastika to kanoume rendering
        }


        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return View();
        }
    }
}