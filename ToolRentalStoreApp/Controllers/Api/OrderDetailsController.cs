using System.Linq;
using System.Web.Http;
using ToolRentalStoreApp.Models;

namespace ToolRentalStoreApp.Controllers.Api
{
    public class OrderDetailsController : ApiController
    {
        private ApplicationDbContext _context;

        public OrderDetailsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/orderdetails
        public IHttpActionResult GetOrderDetails()
        {
            var orderDetails = _context.OrderDetails.ToList();
            return Ok(orderDetails);
        }
    }
}
