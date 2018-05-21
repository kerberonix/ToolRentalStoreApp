using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToolRentalStoreApp.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        // GET: Orders/New
        public ActionResult New()
        {
            return View();
        }

        // GET: Orders/ViewOrder
        public ActionResult ViewOrder()
        {
            return View();
        }
    }
}