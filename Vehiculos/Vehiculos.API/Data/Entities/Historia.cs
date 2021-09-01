using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vehiculos.API.Data.Entities
{
    /// <summary>
    /// Historia de todas las veces que ha llevado el vehiculo a mantenimiento
    /// </summary>
    public class Historia
    {
        public int Id { get; set; }

        [Display(Name = "Vehículo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Vehiculo Vehiculo { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime FechaLocal => Fecha.ToLocalTime();

        [Display(Name = "Kilometraje")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Kilometraje { get; set; }

        [Display(Name = "Observación")]
        [DataType(DataType.MultilineText)]
        public string Observacion { get; set; }

        [JsonIgnore]
        [Display(Name = "Mecánico")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Usuario Usuario { get; set; }

        public ICollection<Detalle> Detalles { get; set; }

        [Display(Name = "# Detalles")]
        public int DetallesCount => Detalles == null ? 0 : Detalles.Count;

        [Display(Name = "Total Mano de Obra")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalManoObra => Detalles == null ? 0 : Detalles.Sum(x => x.PrecioManoObra);

        [Display(Name = "Total Repuestos")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalRepuestos => Detalles == null ? 0 : Detalles.Sum(x => x.PrecioRepuestos);

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Total => Detalles == null ? 0 : Detalles.Sum(x => x.PrecioTotal);
    }
}
