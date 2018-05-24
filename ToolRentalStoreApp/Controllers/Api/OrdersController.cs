using System;
using System.Linq;
using System.Web.Http;
using ToolRentalStoreApp.Dtos;
using ToolRentalStoreApp.Models;
using System.Data.Entity;
using AutoMapper;

namespace ToolRentalStoreApp.Controllers.Api
{
    public class OrdersController : ApiController
    {
        private ApplicationDbContext _context;

        public OrdersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/orders
        public IHttpActionResult GetOrders()
        {
            var orders = _context.Orders
                .Include(c => c.Customer)
                .ToList()
                .Select(Mapper.Map<Order, OrderDto>);

            return Ok(orders);
        }

        // GET: /api/orders/1
        public IHttpActionResult GetOrder(int id)
        {
            var order = _context.OrderDetails
            .Where(c => c.OrderId == id)
            .Include(c => c.Product)
            .Include(c => c.Order.Customer)
            .Select(Mapper.Map<OrderDetail, OrderProductDetailsDto>)
            .ToList();

            return Ok(order);
        }
        
        // POST: /api/orders
        [HttpPost]
        public IHttpActionResult CreateOrder(OrderDetailDto dto)
        {
            var customer = _context.Customers.Single(c => c.Id == dto.CustomerId);

            // retrieve products from database
            var products = _context.Products.Where(c => dto.ProductIds.Contains(c.Id)).ToList();
            // get the dto productIds
            // join the products retrieved with the products in the dto (where the dtoId is equal to the product retrieved Id property)
            // select the products in database and execute query
            // This joins ("inner") the dto.ProductIds with the products list. In this way the rows are "multiplied" when necessary
            var joinedProducts = (from dtoIDs in dto.ProductIds
                           join productsInDb in products on dtoIDs equals productsInDb.Id
                           select productsInDb).ToList();

            var order = new Order
            {
                Customer = customer,
                CustomerId = customer.Id,
                DateOfOrder = DateTime.Now
            };

            foreach (var product in joinedProducts)
            {
                if (product.Quantity == 0)
                    return BadRequest("Product is not available.");

                var orderDetail = new OrderDetail
                {
                    Product = product,
                    ProductId = product.Id,
                    OrderId = order.Id
                };
                product.Quantity--;

                _context.OrderDetails.Add(orderDetail);
            }

            _context.Orders.Add(order);

            _context.SaveChanges();
            return Ok();
        }

        // DELETE: /api/orders/1
        [HttpDelete]
        public IHttpActionResult DeleteOrder(int id)
        {
            var orderInDb = _context.Orders.SingleOrDefault(c => c.Id == id);

            if (orderInDb == null)
                return NotFound();

            _context.Orders.Remove(orderInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
