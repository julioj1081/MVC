using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Filtros;
using CursoMVC.Models.ViewModels;

namespace CursoMVC.Controllers
{
    [VerificacionSession]
    public class ArchivoController : Controller
    {
        // GET: Archivo
        public ActionResult Index()
        {
            

            return View();
        }

        [HttpPost]
        public ActionResult Save(ArchivoViewModel model)
        {
            //guarda los 2 archivos en una carpeta en especifica
            string RutaSitio = Server.MapPath("~/");
            string PathArchivo1 = Path.Combine(RutaSitio + "/Archivos/archivo1.png");
            string PathArchivo2 = Path.Combine(RutaSitio + "/Archivos/archivo2.png");
            if (!ModelState.IsValid)
            {
                return View("Index",model);
            }
            model.Archivo1.SaveAs(PathArchivo1);
            model.Archivo1.SaveAs(PathArchivo2);
            return RedirectToAction("Index");
        }
    }
}