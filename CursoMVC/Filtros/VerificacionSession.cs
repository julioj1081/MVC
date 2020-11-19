using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//importante
using System.Web.Mvc;
using CursoMVC.Controllers;
using CursoMVC.Models;
namespace CursoMVC.Filtros
{
    public class VerificacionSession: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //verificamos si el usuario existe
            var user = (usuarios)HttpContext.Current.Session["usuario"];
            if(user == null)
            {
                //vete a una ruta en especifico sin este if seria un while en infinito
                if(filterContext.Controller is AccesoController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceso/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccesoController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}