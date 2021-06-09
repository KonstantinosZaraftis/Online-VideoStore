using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vindly1.Models;
using Vindly1.ViewModel;
using System.Data.Entity;

namespace Vindly1.Controllers
{
    public class CustomersController : Controller
    {
        //ApplicationDbContext db = new Models.ApplicationDbContext();
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Customers
        public ActionResult Index()
        {

            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
           
            return View(customers);

           
        }


        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            
            var viewModel = new NewCustomerViewModel()
            {
                
                MembershipTypes = membershipTypes
            };
            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);


                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.IsSubscidedToNewsletter = customer.IsSubscidedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");

            
        }
        public ActionResult Details(int? id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //if (customer == null)
            //{
            //    return HttpNotFound();
            //}
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Customer customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new NewCustomerViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View(viewModel);
        }

    }
}