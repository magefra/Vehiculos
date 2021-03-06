using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehiculos.API.Data.Entities
{
    public class Procedimiento
    {
        public int Id { get; set; }


        [DisplayName("Procedemiento")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Descripcion { get; set; }


        [DisplayName("Precio")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public decimal Precio { get; set; }


        public ICollection<Detalle> Detalles { get; set; }
    }
}
