using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PRO_finder.Models;


namespace PRO_finder.Controllers
{
    
    public class ClientController : MyControllerBase
    {
        // GET: Client
       
        public ActionResult Index()
        {
            return View();
        }
        
    }
}