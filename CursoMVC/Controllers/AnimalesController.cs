using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
using CursoMVC.Models.TablasModelos;

namespace CursoMVC.Controllers
{
    public class AnimalesController : Controller
    {
        // GET: Animales
        public ActionResult Index()
        {
            List<SelectListItem> list1 = new List<SelectListItem>();
            using (Models.CursoMVCEntities db = new Models.CursoMVCEntities())
            {
                list1 = (from d in db.Animales_class
                         select new SelectListItem
                         {
                             Value = d.Id.ToString(),
                             Text = d.Especie
                         }).ToList();

                list1.Insert(0, new SelectListItem { Text = "-- Seleccione --", Value = "" });
            }
            return View(list1);
        }

        [HttpGet]
        public JsonResult Animal(int ID)
        {
            List<ElementJsonIntKey> lst = new List<ElementJsonIntKey>();
            using(var bd = new Models.CursoMVCEntities())
            {
                lst = (from d in bd.Animal
                       where d.idAnimal_class == ID
                       select new ElementJsonIntKey
                       {
                           Value = d.Id,
                           Text = d.Nombre
                       }).ToList();
                lst.Insert(0, new ElementJsonIntKey { Value = int.Parse("0"), Text = "--Seleccione--" });

            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public class ElementJsonIntKey{
            public int Value { get; set; }
            public string Text { get; set; }
        }

      
        public JsonResult Tabla_Desc(int Id)
        {
            List<AnimalesCLS> lista = new List<AnimalesCLS>();
            using(var bd = new CursoMVCEntities())
            {
                lista = (from item in bd.Animal
                         where item.Id == Id
                         select new AnimalesCLS
                         {
                             Id = item.Id,
                             Nombre = item.Nombre,
                             idAnimal_class = item.idAnimal_class.ToString()
                         }).ToList();

            }
            return Json(lista, JsonRequestBehavior.AllowGet);
        }






    }
}