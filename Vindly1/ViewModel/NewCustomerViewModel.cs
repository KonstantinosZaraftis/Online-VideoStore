using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vindly1.Models;

namespace Vindly1.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
       
    }
}