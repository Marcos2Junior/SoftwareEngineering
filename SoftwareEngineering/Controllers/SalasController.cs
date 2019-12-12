using SoftwareEngineering.Business;
using SoftwareEngineering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftwareEngineering.Controllers
{
    public class SalasController : Controller
    {
        // GET: NovaSala
        public ActionResult NovaSala()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NovaSala(Sala sala)
        {
            DAL obj = new DAL();
            obj.GravarSala(sala);

            return View(sala);
        }
    }
}