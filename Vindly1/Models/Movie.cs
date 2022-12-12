using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vindly1.Models
{
    
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsRental { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }


    }
}