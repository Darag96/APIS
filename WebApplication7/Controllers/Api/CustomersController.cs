using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication7.Models;

namespace WebApplication7.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private Context _context ;

        public CustomersController()
        {
            _context = new Context();
        }

        // GET api/customers
        public IEnumerable<Customer> GetCustomers ()
        {
            return _context.Customers.ToList();
        }

        // GET api/customers/1
        public IHttpActionResult GetCustomer (int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok(customer) ;
        }

        // POST api/customer
        [HttpPost]
        // it was returning a customer object
        public IHttpActionResult CreateCustomer (Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id ) , customer);
        }
        
        // PUT api/customer/1
        [HttpPut]
        public void UpdateCustomer (int id , Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb =  _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;

            _context.SaveChanges();
        } 

        // DELETE api/customer/1
        [HttpDelete]
        public void DeleteCustomer (int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
