using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolRentalStoreApp.Dtos;
using ToolRentalStoreApp.Models;

namespace ToolRentalStoreApp.Controllers.Api
{
    public class ProductsQuantityController : ApiController
    {
        private ApplicationDbContext _context;

        public ProductsQuantityController()
        {
            _context = new ApplicationDbContext();
        }

        // this action updates the product stock when an order is deleted
        // POST: /api/products
        [HttpPost]
        public IHttpActionResult UpdateQuantity(ProductQuantityDto dto)
        {
            var productsInDb = _context.Products.Where(c => dto.ProductIds.Contains(c.Id)).ToList();

            foreach (var product in productsInDb)
            {
                product.Quantity++;
            }

             _context.SaveChanges();

             return Ok();
        }
    }
}
