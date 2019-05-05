using OdeToFoodWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace OdeToFoodWithAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        public ActionResult AutoComplete(string term)
        {
            var model =
                _db.Restaurants
                .Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new

                {
                    label = r.Name
                });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Index(string searchString, int page = 1)
        {
           IPagedList<RestaurantListViewModel> model = _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchString == null || r.Name.StartsWith(searchString))
                .Select(r => new RestaurantListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                        CountOfReviews = r.Reviews.Count()

                    }).ToPagedList(page, 10); 

            /*   IQueryable<RestaurantListViewModel> model =
                   from r in _db.Restaurants
                   orderby r.Reviews.Average(review => review.Rating) descending
                   select new RestaurantListViewModel {
                       Id = r.Id,
                       Name = r.Name,
                       City = r.City,
                       Country = r.Country,
                       CountOfReviews = r.Reviews.Count()
                   }; */

            

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }
          

            return View(model);
        }

       /* [HttpPost]
        public string Index(string searchString, bool notUsed = true)
        {
            return "From [HttpPost] Index: filter on " + searchString;
        } */

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

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}