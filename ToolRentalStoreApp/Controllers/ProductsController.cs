﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ToolRentalStoreApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        // GET: Products/New
        public ActionResult New()
        {
            return View();
        }

        // GET: Products/Edit
        public ActionResult Edit()
        {
            return View();
        }
    }
}