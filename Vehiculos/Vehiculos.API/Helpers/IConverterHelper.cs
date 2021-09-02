using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data.Entities;
using Vehiculos.API.Models;

namespace Vehiculos.API.Helpers
{
    public interface IConverterHelper
    {
        Task<Usuario> ToUserAsync(UsuarioViewModel model, Guid imageId, bool isNew);

        UsuarioViewModel ToUserViewModel(Usuario user);
    }
}
