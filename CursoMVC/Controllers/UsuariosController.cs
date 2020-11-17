using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//modelo
using CursoMVC.Models;
using CursoMVC.Models.TablasModelos;
namespace CursoMVC.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            List<UsuariosCLS> lista = null;
            using(var bd = new CursoMVCEntities())
            {
                lista = (from d in bd.usuarios
                         where d.idEstado == 1
                         orderby d.email
                         select new UsuariosCLS
                         {
                             Email = d.email,
                             Id = d.id,
                             Edad = d.edad
                         }).ToList();
            }
            return View(lista);
        }
    }
}