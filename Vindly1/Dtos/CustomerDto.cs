using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vindly1.Dtos
{
    public class CustomerDto
    {

        public int Id { get; set; }
        
        public string Name { get; set; }
        public bool IsSubscidedToNewsletter { get; set; }
        
        public DateTime? Birthdate { get; set; }

        





    }
}