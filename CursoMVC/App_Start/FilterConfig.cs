using System.Web;
using System.Web.Mvc;

namespace CursoMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //agregado de filtro para evaluar la session de usuario en Acceso
            filters.Add(new Filtros.VerificacionSession());
        }
    }
}
