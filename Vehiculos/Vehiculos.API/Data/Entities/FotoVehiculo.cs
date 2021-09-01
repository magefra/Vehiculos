using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehiculos.API.Data.Entities
{
    public class FotoVehiculo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehiculo Vehiculo { get; set; }

        [Display(Name = "Foto")]
        public Guid IdImagen { get; set; }

        [Display(Name = "Foto")]
        public string ImageFullPath => IdImagen == Guid.Empty
            ? $"https://localhost:44320/img/noimage.png"
            : $"https://localhost:44320/users/{IdImagen}";
    }
}
