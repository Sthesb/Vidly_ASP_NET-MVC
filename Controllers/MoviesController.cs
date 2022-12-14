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

        // edit movie
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m=> m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };


            return View("MovieForm", viewModel);

        }

        // save or update movie
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            // checks if model state is valid
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }


            if(movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m=> m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate; 
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}