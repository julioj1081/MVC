using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//importar
using System.ComponentModel.DataAnnotations;
namespace CursoMVC.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        [Display(Name ="Correo Electronico")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        
        [Display(Name = "CPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las constraseñas no son iguales")]
        public string CPassword { get; set; }
        
        [Required]
        public int Edad { get; set; }
    }
}