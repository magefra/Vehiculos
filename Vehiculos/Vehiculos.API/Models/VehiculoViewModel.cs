using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vehiculos.API.Models
{
    public class VehiculoViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Tipo de vehículo")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar un tipo de vehículo.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int IdTipoVehiculo { get; set; }

        public IEnumerable<SelectListItem> TipoVehiculos { get; set; }

        [Display(Name = "Marca")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una marca")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int idMarca { get; set; }

        public IEnumerable<SelectListItem> Marcas { get; set; }


        [Display(Name = "Modelo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Range(1900, 3000, ErrorMessage = "Valor de módelo no válido.")]
        public int Modelo { get; set; }

        [Display(Name = "Placa")]
        [RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage = "Formato de placa incorrecto.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Placa { get; set; }

        [Display(Name = "Línea")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Linea { get; set; }

        [Display(Name = "Color")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Color { get; set; }

       
        public string IdUsuario { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }


        [Display(Name ="Foto")]
        public IFormFile ImagenFile { get; set; }
    }
}
