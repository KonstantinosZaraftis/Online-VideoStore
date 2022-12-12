using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vindly1.Models;

namespace Vindly1.ViewModel
{
    public class CustomerMovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Customer> Customers { get; set; }


    }
}