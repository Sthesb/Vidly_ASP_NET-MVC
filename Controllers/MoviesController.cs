﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        

        // random
        public ActionResult Random()
        {
            var movie = new Movie { Id = 1, Name = "Shrek!" };

            //return View(movie);
            //return Content("Hello World!");
            //return HttpNotFound();
            //return new EmptyResult();

            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name"});
        }

        
        // ByReleasedDate
        public ActionResult ByReleasedDate(int year, int month)
        {

            return Content(year + " / " + month);
        }
    }
}