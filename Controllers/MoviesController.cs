using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context { get; set; }
        public MoviesController ()
        {
            _context = new ApplicationDbContext ();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ViewResult Index()
        {
            var movies = _context.Movies.Include(m=> m.Genre).ToList();

            return View(movies);
        }

        // get movie details
        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m=> m.Genre).SingleOrDefault(m=> m.Id == id);
            if(movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // movie form
        public ActionResult Create ()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        // save or update movie
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie == null)
                return HttpNotFound ();
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}