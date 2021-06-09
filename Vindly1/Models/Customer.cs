using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vindly1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]//etsi den tha pernei null times dhladh den tha einai nullable
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscidedToNewsletter { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
        
        public MembershipType MembershipType { get; set; }
        
        public int MembershipTypeId { get; set; }


    }
}