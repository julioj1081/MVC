using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CursoMVC.Models.TablasModelos
{
    public class AnimalesCLS
    {
        [Display(Name ="Id")]
        public int Id { get; set; }

        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

        [Display(Name ="IdAnimal_class")]
        public string idAnimal_class { get; set; }
    }
}