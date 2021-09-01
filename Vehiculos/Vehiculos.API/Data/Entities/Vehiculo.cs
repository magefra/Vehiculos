using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vehiculos.API.Data.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de vehículo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public VehiculoTipo TipoVehiculo { get; set; }

        [Display(Name = "Marca")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Marca Marca { get; set; }

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

        [Display(Name = "Propietario")]
        [JsonIgnore]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Usuario Usuario { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }

        public ICollection<FotoVehiculo> VehiculoFotos { get; set; }

        [Display(Name = "# Fotos")]
        public int FotoVehiculoCount => VehiculoFotos == null ? 0 : VehiculoFotos.Count;

        [Display(Name = "Foto")]
        public string ImagenFullPath => VehiculoFotos == null || VehiculoFotos.Count == 0
           ? $"https://localhost:44320/img/noimage.png"
            : VehiculoFotos.FirstOrDefault().ImageFullPath;

        public ICollection<Historia> Historias { get; set; }

        [Display(Name = "# Historias")]
        public int HistoriasCount => Historias == null ? 0 : Historias.Count;
    }
}
