using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vindly1.Models;

namespace Vindly1.ViewModel
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers{ get; set; }


    }
}

//var customer = new List<Customer>() {
//                new Customer(){ Id = 1, Name="Bill"},
//                new Customer(){ Id = 2, Name="Steve"},
//                new Customer(){ Id = 3, Name="Ram"},
//                new Customer(){ Id = 4, Name="Abdul"}
//            };
