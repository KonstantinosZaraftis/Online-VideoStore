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
        
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
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


        //public ActionResult Create()
        //{

        //    return View();
        //}

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");



        }
       

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var customer = _context.Customers.Find(id);
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


         [HttpPost]
         public ActionResult Edit(Customer customer)
         {
            if (ModelState.IsValid)
              
             _context.Entry(customer).State = EntityState.Modified;
            
             _context.SaveChanges();
             return RedirectToAction("Index","Customers");
            
            
         }
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
           
            return View(customer);
        }

        
    }
}