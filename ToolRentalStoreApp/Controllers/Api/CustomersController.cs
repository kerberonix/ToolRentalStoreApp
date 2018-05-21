using System;
using System.Web.Http;
using System.Linq;
using ToolRentalStoreApp.Models;
using ToolRentalStoreApp.Dtos;
using AutoMapper;

namespace ToolRentalStoreApp.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _context.Customers.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customersDto = customersQuery.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customersDto);
        }

        // GET: /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            // using Automapper to map CustomerDto properties to Customer properties
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST: /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // using Automapper to map CustomerDto properties to Customer properties
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            customer.DateAdded = DateTime.Now;

            _context.Customers.Add(customer);
            _context.SaveChanges();

            // as part of RESTful convention, we need to return the URI of the newly created resource to the client
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT: /api/customers/1
        [HttpPut]
        public IHttpActionResult EditCustomer(int id, CustomerDto customerDto)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            // second argument: we don't need to create a new object, we need to modify an existing one
            // which is 'customerInDb' so we pass it as a second argument
            // if you don't pass a second argument, automapper automatically creates a destination object it performs the mapping to
            Mapper.Map<CustomerDto, Customer>(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE: /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }

}
