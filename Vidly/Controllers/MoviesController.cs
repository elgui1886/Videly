using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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


        
        // GET: Movies/Random
        public ActionResult Random()
        {
            //qui dovrei inserire una chiamata al mio db Locale
            var movie = new Movie() {Name = "Shrek!"};

            var customers = new List<Customer>
            {
                new Customer { Name="Customer 1"},
                new Customer { Name="Customer 2"},
                new Customer { Name="Customer 3"},
                new Customer { Name="Customer 4"},
                new Customer { Name="Customer 5"},
                new Customer { Name="Customer 6"},
                new Customer { Name="Customer 7"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //se ritorno una View, devo passare un model alla view (se la view è tipizzata)
            //Metodo1
            return View(viewModel);

            //Metodo2
            //ViewData["Movie"] = movie;

            //Metodo3
            //ViewBag.Movie = movie;  //Aggiunta a runtiame alla ViewBag
            //return View();




            //return Content("Hello world");
            //return HttpNotFound("Non trovato");
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy="name"}); 
            //oggetto anonimo come terzo argomento
            //sono i parametri da passare alla nuova action alla quale faccio redirect
                                     
        }

        
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

        
        public ActionResult Index(string fristParam, string secondParam)
        {
            if (string.IsNullOrEmpty(fristParam) && string.IsNullOrEmpty(secondParam))
            {
                return Content(string.Format("Nessun parametro selezionato"));
            }
            return Content(string.Format("fristParam = {0}, secondParam = {1}", fristParam, secondParam));
        }

        [Route("released/{fristParam?}/{secondParam?}")] //per inserire i constraint sugli input, scrivi {month:regex(\\d{4})}
        public ActionResult ByReleaseDate(string fristParam, string secondParam)
        {
            if (string.IsNullOrEmpty(fristParam) && string.IsNullOrEmpty(secondParam))
            {
                return Content(string.Format("Nessun parametro selezionato"));
            }
            return Content(string.Format("fristParam = {0}, secondParam = {1}", fristParam, secondParam));
        }

    }
}