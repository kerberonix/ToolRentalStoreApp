using System;
using System.Web.Http;
using System.Linq;
using ToolRentalStoreApp.Models;
using ToolRentalStoreApp.Dtos;
using AutoMapper;

namespace ToolRentalStoreApp.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/products
        public IHttpActionResult GetProducts(string query = null)
        {
            var productsQuery = _context.Products.AsQueryable();

            if (!String.IsNullOrWhiteSpace(query))
                productsQuery = productsQuery.Where(c => c.Name.Contains(query));

            var productsDto = productsQuery.ToList().Select(Mapper.Map<Product, ProductDto>);

            return Ok(productsDto);
        }

        // GET: /api/products/1
        public IHttpActionResult GetProduct(int id)
        {
            var product = _context.Products.SingleOrDefault(c => c.Id == id);

            if (product == null)
                return NotFound();

            // using Automapper to map ProductDto properties to Product properties
            return Ok(Mapper.Map<Product, ProductDto>(product));
        }

        // POST: /api/products
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // using Automapper to map ProductDto properties to Product properties
            var product = Mapper.Map<ProductDto, Product>(productDto);
            product.DateAdded = DateTime.Now;

            _context.Products.Add(product);
            _context.SaveChanges();

            // as part of RESTful convention, we need to return the URI of the newly created resource to the client
            return Created(new Uri(Request.RequestUri + "/" + product.Id), productDto);
        }

        // PUT: /api/products/1
        [HttpPut]
        public IHttpActionResult EditProduct(int id, ProductDto productDto)
        {
            var productInDb = _context.Products.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();

            // second argument: we don't need to create a new object, we need to modify an existing one
            // which is 'productInDb' so we pass it as a second argument
            // if you don't pass a second argument, automapper automatically creates a destination object it performs the mapping to
            Mapper.Map<ProductDto, Product>(productDto, productInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE: /api/products/1
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var productInDb = _context.Products.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();

            _context.Products.Remove(productInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
