using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vehiculos.API.Data.Entities
{
    public class VehiculoTipo
    {

        public int Id { get; set; }


        [DisplayName("Tipo de vehículo")]
        [MaxLength(50, ErrorMessage ="El campo {0} no puede tener más de {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Descripcion { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public ICollection<Vehiculo> Vehiculos { get; set; }




    }
}
