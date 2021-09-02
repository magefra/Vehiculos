﻿
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehiculos.API.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetCombosTipoDocumentos();

        IEnumerable<SelectListItem> GetCombosProcedimientos();

        IEnumerable<SelectListItem> GetCombosTíposVehculos();

        IEnumerable<SelectListItem> GetCombosMarcas();
    }
}
