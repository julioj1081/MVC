using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        //
        public ActionResult Enter(string user, string pass)
        {
            try
            {

                return Content("1");
            }catch(Exception e) { return Content("Ocurrio un error :(" + e.Message); }
           
        }
    }
}