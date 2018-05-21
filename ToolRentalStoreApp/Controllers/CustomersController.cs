using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToolRentalStoreApp.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/New
        public ActionResult New()
        {
            return View();
        }

        // GET: Customers/Edit
        public ActionResult Edit()
        {
            return View();
        }
    }
}