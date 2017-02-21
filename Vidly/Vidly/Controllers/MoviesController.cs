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
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose( );
        }
        public  ViewResult  Index()
        {
            var movies = _context.Movies.Include( m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        //private IEnumerable<Movie> GetMovies()
        //{
        //    return new List<Movie>
        //    {
        //        new Movie { Id=1,Name="Shrek" },
        //        new Movie { Id=2,Name="Wall-e" },

        //    };
        //}
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //---------------------------------------------------------------
            // this is oldway, very fragile. 
            //ViewData["Movie"] = movie;

            //--------------------------------------------------------------
            //ViewBag ,movie is added at run ning time , not complie safety ,
            //ViewBag.Movie = movie;


            //------------------------------------------------------------
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model = movie;


            //---------------------------------------------------------------
            // 

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer1" },
                new Customer {Name = "Customer2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }
        //  Change route, constrain , contribute routing, 
       // [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12))}")]


        public ActionResult Edit(int id)
        {
            return Content("id" + id);
        }
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex =1;
        //    }
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(String.Format("pageIndex={0}& sortBy={1}", pageIndex, sortBy));
        //}
        public ActionResult ByReleaseDATE( int year, int month)
        {
            return Content(year+"/"+month);
        }
      
    }
}