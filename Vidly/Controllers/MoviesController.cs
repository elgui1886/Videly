using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    [RoutePrefix("Movies")]
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("Random")]
        // GET: Movies/Random
        public ActionResult Random()
        {
            //qui dovrei inserire una chiamata al mio db Locale
            var movie = new Movie() {Name = "Shrek!"};
            return View(movie);
        }
    }
}