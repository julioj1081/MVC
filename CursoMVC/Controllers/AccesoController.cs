using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMVC.Models;
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
                //hacemos una busqueda
                using(var bd = new CursoMVCEntities())
                {
                    var lista = from d in bd.usuarios
                                where d.email == user && 
                                d.password == pass && 
                                d.idEstado == 1
                                select d;
                    //si encuentra uno 
                    if (lista.Count() > 0)
                    {
                        usuarios usu = lista.First();
                        Session["usuario"] = usu;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido");
                    }
                }
            }catch(Exception e) { return Content("Ocurrio un error :(" + e.Message); }
           
        }
    }
}