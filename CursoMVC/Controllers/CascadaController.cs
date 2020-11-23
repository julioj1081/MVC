using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Filtros;
using CursoMVC.Models;
using CursoMVC.Models.ViewModels;
namespace CursoMVC.Controllers
{
    [VerificacionSession]
    public class CascadaController : Controller
    {
        // GET: CascadaPaises
        public ActionResult Index()
        {
            CursoMVCEntities bd = new CursoMVCEntities();
            ViewBag.PaisesLista = new SelectList(GetPaisesList(), "Pais_id", "Pais_nombre");
            return View();
        }

        public List<Paises> GetPaisesList()
        {
            CursoMVCEntities db = new CursoMVCEntities();
            List<Paises> paises = db.Paises.ToList();
            return paises;
        }

        public ActionResult GetEstadosList(int Pais_id)
        {
            CursoMVCEntities db = new CursoMVCEntities();
            List<Estados> selectList = db.Estados.Where(d => d.Pais_id == Pais_id).ToList();
            ViewBag.EstadosLista = new SelectList(selectList, "Estado_id", "Estado_nombre");
            return PartialView("DisplayEstados");
        }

        public ActionResult GetCiudadesList(int Estado_id)
        {
            CursoMVCEntities db = new CursoMVCEntities();
            List<Ciudades> selectList = db.Ciudades.Where(d => d.Estado_id == Estado_id).ToList();
            ViewBag.CiudadLista = new SelectList(selectList, "Ciudad_id", "Ciudad_nombre");
            return PartialView("DisplayCiudades");
        }
    }
}