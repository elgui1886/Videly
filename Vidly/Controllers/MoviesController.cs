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
            //return View(movie);
            //return Content("Hello world");
            //return HttpNotFound("Non trovato");
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new { page = 1, sortBy="name"}); 
            //oggetto anonimo come terzo argomento
            //sono i parametri da passare alla nuova action alla quale faccio redirect
                                     
        }

        [HttpGet]
        [Route("Edit")]
        public ActionResult Edit(int? id)
        {

            if (id.HasValue)
            {
                return Content("Id passato al metodo: " + id.ToString());
            }
            else
            {
                return new EmptyResult();
            }
            
        }

        [HttpGet]
        [Route("")]
        public ActionResult Index(string fristParam, string secondParam)
        {
            if (string.IsNullOrEmpty(fristParam) && string.IsNullOrEmpty(secondParam))
            {
                return Content(string.Format("Nessun parametro selezionato"));
            }
            return Content(string.Format("fristParam = {0}, secondParam = {1}", fristParam, secondParam));
        }

        [HttpGet]
        [Route("ByReleaseDate")]
        public ActionResult ByReleaseDate(string fristParam, string secondParam)
        {
            if (string.IsNullOrEmpty(fristParam) && string.IsNullOrEmpty(secondParam))
            {
                return Content(string.Format("Nessun parametro selezionato"));
            }
            return Content(string.Format("fristParam = {0}, secondParam = {1}", fristParam, secondParam));
        }

        [HttpGet]
        [Route("ByDefault")]
        public ActionResult ByDefault(string fristParam, string secondParam)
        {
            return Content(string.Format("Metodo di default"));
        }
    }
}