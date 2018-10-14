using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicCollection.Controllers
{
    /// <summary>
    /// Controls Home window
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Method which returns index view
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Method which returns about view
        /// </summary>
        public ActionResult About()
        {
            
            return View();
        }
        /// <summary>
        /// Method which returns contact view
        /// </summary>
        public ActionResult Contact()
        {

            return View();
        }
    }
}