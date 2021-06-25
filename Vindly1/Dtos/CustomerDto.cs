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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscidedToNewsletter { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public int MembershipTypeId { get; set; }





    }
}