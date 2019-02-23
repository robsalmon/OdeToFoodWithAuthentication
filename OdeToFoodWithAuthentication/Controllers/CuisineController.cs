using OdeToFoodWithAuthentication.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFoodWithAuthentication.Controllers
{
   // [Authorize]
   [Log]
    public class CuisineController : Controller
    {
        // GET: Cuisine
       
        public ActionResult Search(string name = "French")
        {
            throw new Exception("Something terrible has happened");
            //var message = Server.HtmlEncode(name);
            //return Content(message);
        }
    }
}