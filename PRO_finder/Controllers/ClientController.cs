using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PRO_finder.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        // GET: Client
        [Authorize(Users ="Kevin@gmail.com")]
        public ActionResult Index()
        {
            return View();
        }
    }
}