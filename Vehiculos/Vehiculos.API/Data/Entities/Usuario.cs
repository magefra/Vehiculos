using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vehiculos.Common.Enums;

namespace Vehiculos.API.Data.Entities
{
    public class Usuario : IdentityUser
    {
        [DisplayName("Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }

        [DisplayName("Apellidos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Apellidos { get; set; }

        [DisplayName("TipoDocumento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public TipoDocumento TipoDocumento { get; set; }


        [DisplayName("Documento")]
        [MaxLength(20, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Documento { get; set; }

        [DisplayName("Direccion")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string Direccion { get; set; }

        [DisplayName("Foto")]
        public Guid IdImagen { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => IdImagen == Guid.Empty
            ? $"https://localhost:44320/img/noimage.png"
            : $"https://localhost:44320/users/{IdImagen}";


        [Display(Name = "TipoUsuario")]
        public TipoUsuario TipoUsuario { get; set; }

        [Display(Name = "Nombre Completo")]
        public string NombreCompleto => $"{Nombre} {Apellidos}";


        public ICollection<Vehiculo> Vehiculos { get; set; }

      

    }
}
