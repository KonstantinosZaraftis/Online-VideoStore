using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Vindly1.Dtos;
using Vindly1.Models;


namespace Vindly1.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
           _context = new ApplicationDbContext();
        }
            
        //GET/api/customers
        [System.Web.Http.HttpGet]
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        //GET/api/customers/1
        public CustomerDto GetCustomer(int id)
        {
            var customer= _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Customer,CustomerDto>(customer);
        }
        //POST/api/customers ftiaxno customer
        [System.Web.Http.HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)

             throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerDto.Id = customerDto.Id;
             return customerDto;
        }

        //PUT/api/customers/1
        [System.Web.Http.HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            
                throw new HttpResponseException(HttpStatusCode.BadRequest);
                var customerInDb = _context.Customers.SingleOrDefault(x => x.Id == id);
                if(customerInDb==null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
           var c= Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);
            //customerInDb.Name = customer.Name;
            //customerInDb.Birthdate = customer.Birthdate;
            //customerInDb.IsSubscidedToNewsletter = customer.IsSubscidedToNewsletter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();
        }
        //DELETE/api/customer/1
        [System.Web.Http.HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }
       
    }
}
