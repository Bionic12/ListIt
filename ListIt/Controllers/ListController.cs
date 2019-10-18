using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ListIt.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        // GET: List
        public ActionResult See()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }


    }
}