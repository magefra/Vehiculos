using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data.Entities;
using Vehiculos.Common.Enums;

namespace Vehiculos.API.Models
{
    public class UsuarioViewModel
    {


        public string Id { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Debes introducir un email válido.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Email { get; set; }


        [DisplayName("Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [DisplayName("Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apellidos { get; set; }

        


        [DisplayName("Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Documento { get; set; }

        [DisplayName("Direccion")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Direccion { get; set; }


        [DisplayName("Telefono")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Telefono { get; set; }

        [DisplayName("Foto")]
        public Guid IdImagen { get; set; }

        


        [Display(Name = "TipoUsuario")]
        public TipoUsuario TipoUsuario { get; set; }

      
        [Display(Name = "Foto")]
        public IFormFile ImagenFile { get; set; }


        [Display(Name = "Tipo de documento")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de documento.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int IdTipoDocumentos { get; set; }

        public IEnumerable<SelectListItem> TipoDocumentos { get; set; }




    }
}
