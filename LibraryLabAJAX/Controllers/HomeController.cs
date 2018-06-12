using LibraryLabAJAX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryLabAJAX.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetBooksByAuthor(string author)
        {
            LibraryEntities db = new LibraryEntities();

           
            List<book> list = db.books.Where(
               a => a.Author.Contains(author)
                ).ToList();

            return Json(list);
        }
        [HttpPost]
        public ActionResult GetBooksByTitle(string title)
        {
            LibraryEntities db = new LibraryEntities();

            List<book> list = db.books.Where(
                              t => t.Title.Contains(title)
                              ).ToList();

            return Json(list);
        }
        //? means the parameter can be null
        public ActionResult GetBooksByYear(int? year)
        {
            LibraryEntities db = new LibraryEntities();

            List<book> list = db.books.Where(
                              //has to equal the year the user puts in.
                              y => y.YearPublished == (year)
                              ).ToList();

            return Json(list);
        }

        public ActionResult BooksByPublisher()
        {          
            return View();
        }
        [HttpPost]
        public ActionResult GetBooksByPublisher(string publisher)
        {
            LibraryEntities db = new LibraryEntities();

            List<book> list = db.books.Where(
                              t => t.Publisher.Contains(publisher)
                              ).ToList();

            return Json(list);
        }
    }
}