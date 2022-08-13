using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        

        // random
        public ActionResult Random()
        {
            var movie = new Movie { Id = 1, Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Sthembiso"},
                new Customer { Name = "Goodness"},
            };

            var viewModel = new RandomViewModel 
            {
                Movie = movie,
                Customers = customers,
            };

            return View(viewModel);
        }

        
        
    }
}