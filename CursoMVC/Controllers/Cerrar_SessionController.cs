using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class Cerrar_SessionController : Controller
    {
        // GET: Cerrar_Session
        public ActionResult Cerrar()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Acceso");
        }
    }
}