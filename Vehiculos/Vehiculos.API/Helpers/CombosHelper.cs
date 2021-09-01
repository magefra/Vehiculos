using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data;

namespace Vehiculos.API.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;

        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public IEnumerable<SelectListItem> GetCombosMarcas()
        {
            List<SelectListItem> list = _dataContext.Marcas.Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = $"{x.Id}"

            }).OrderBy(x => x.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una marca...]",
                Value = "0"
            });


            return list;
        }

        public IEnumerable<SelectListItem> GetCombosProcedimientos()
        {
            List<SelectListItem> list = _dataContext.Procedimientos.Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = $"{x.Id}"

            }).OrderBy(x => x.Text)
                 .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un procedimiento...]",
                Value = "0"
            });


            return list;
        }

        public IEnumerable<SelectListItem> GetCombosTipoDocumentos()
        {
            List<SelectListItem> list = _dataContext.TipoDocumentos.Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = $"{x.Id}"

            }).OrderBy(x => x.Text)
                 .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de documento...]",
                Value = "0"
            });


            return list;
        }

        public IEnumerable<SelectListItem> GetCombosTíposVehculos()
        {
            List<SelectListItem> list = _dataContext.VehiculosTipo.Select(x => new SelectListItem
            {
                Text = x.Descripcion,
                Value = $"{x.Id}"

            }).OrderBy(x => x.Text)
                            .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un tipo de vehículo...]",
                Value = "0"
            });


            return list;
        }
    }
}
