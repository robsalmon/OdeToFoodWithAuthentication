using OdeToFoodWithAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFoodWithAuthentication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        [HttpGet]
        public ActionResult Index(string searchString)
        {
            IQueryable<RestaurantListViewModel> model = _db.Restaurants.OrderByDescending(
                r => r.Reviews.Average(review => review.Rating))
                    .Select(r => new RestaurantListViewModel
                    {
                        Id = r.Id,
                        Name = r.Name,
                        City = r.City,
                        Country = r.Country,
                        CountOfReviews = r.Reviews.Count()

                    }); 

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

            if (!String.IsNullOrEmpty(searchString)) {

               model = model.Where(s => s.Name.Contains(searchString));
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