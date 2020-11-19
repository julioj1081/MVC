using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        public class ElementJsonIntKey{
            public int Value { get; set; }
            public string Text { get; set; }
        }

    }
}