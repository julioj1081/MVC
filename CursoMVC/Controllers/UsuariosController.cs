using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//modelo
using CursoMVC.Models;
using CursoMVC.Models.TablasModelos;
//para entrar a la carpeta de ViewModels
using CursoMVC.Models.ViewModels;
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

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                using(var db = new CursoMVCEntities())
                {
                    usuarios user = new usuarios();
                    user.idEstado = 1;
                    user.email = model.Email;
                    user.edad = model.Edad;
                    user.password = model.Password;
                    db.usuarios.Add(user);
                    db.SaveChanges();
                }
                return Redirect(Url.Content("~/Usuarios/"));
            }
        }
    
        [HttpGet]
        //entra a formulario
        public ActionResult Modificar(int id)
        {
            EditUsuarioViewModel model = new EditUsuarioViewModel();
            using(var bd = new CursoMVCEntities())
            {
                var ousuario = bd.usuarios.Find(id);
                model.Edad = (int)ousuario.edad;
                model.Email = ousuario.email;
                model.Id = ousuario.id;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(EditUsuarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
                using(var bd = new CursoMVCEntities())
                {
                    var ousu = bd.usuarios.Find(model.Id);
                    ousu.email = model.Email;
                    ousu.edad = model.Edad;
                    if(model.Password!=null && model.Password.Trim() != "")
                    {
                        ousu.password = model.Password;
                    }

                    bd.Entry(ousu).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                }
                return Redirect(Url.Content("~/Usuarios/"));
        }
   
        [HttpPost]
        public ActionResult Delete(int id)
        {
            int estado = 0;
            using(var bd = new CursoMVCEntities())
            {
                var ouser = bd.usuarios.Find(id);
                ouser.idEstado = 0;
                bd.Entry(ouser).State = System.Data.Entity.EntityState.Modified;
                estado = bd.SaveChanges();
            }
            return Content("1");
        }
    }
}