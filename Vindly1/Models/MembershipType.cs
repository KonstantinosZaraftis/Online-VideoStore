using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Vindly1.Models
{
    public class MembershipType
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths{ get; set; }
        public int DiscountRate { get; set; }

    }
}