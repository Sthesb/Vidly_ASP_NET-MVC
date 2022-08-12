using System;
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
        public ActionResult Index()
        {
            var movie = new Movie { Id = 1, Name = "Shrek!" };

            return View(movie);
        }

        // random
        public ActionResult Random()
        {
            var movie = new Movie { Id = 1, Name = "Shrek!" };

            return View(movie);
        }
    }
}