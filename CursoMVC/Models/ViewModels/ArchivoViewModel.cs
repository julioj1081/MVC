using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.ViewModels
{
    public class ArchivoViewModel
    {
        [Required]
        [Display(Name ="Mi archivo")]
        public HttpPostedFileBase Archivo1 { get; set; }
        [Required]
        [Display(Name = "Mi archivo2")]
        public HttpPostedFileBase Archivo2 { get; set; }
        [Required]
        [Display(Name = "Cadena")]
        public string Cadena { get; set; }
    }
}