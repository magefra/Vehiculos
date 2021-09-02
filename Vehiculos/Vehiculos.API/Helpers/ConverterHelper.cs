using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehiculos.API.Data;
using Vehiculos.API.Data.Entities;
using Vehiculos.API.Models;

namespace Vehiculos.API.Helpers
{
    public class ConverterHelper : IConverterHelper
    {

        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="imageId"></param>
        /// <param name="isNew"></param>
        /// <returns></returns>
        public async Task<Usuario> ToUserAsync(UsuarioViewModel model, Guid imageId, bool isNew)
        {
            return new Usuario
            {
                Direccion = model.Direccion,
                Documento = model.Documento,
                TipoDocumento = await _context.TipoDocumentos.FindAsync(model.IdTipoDocumentos),
                Email = model.Email,
                Nombre = model.Nombre,
                Id = isNew ? Guid.NewGuid().ToString() : model.Id,
                IdImagen = imageId,
                Apellidos = model.Apellidos,
                PhoneNumber = model.Telefono,
                UserName = model.Email,
                TipoUsuario = model.TipoUsuario
            };
        }

        public UsuarioViewModel ToUserViewModel(Usuario user)
        {
            return new UsuarioViewModel
            {
                Direccion = user.Direccion,
                Documento = user.Documento,
                IdTipoDocumentos = user.TipoDocumento.Id,
                TipoDocumentos = _combosHelper.GetCombosTipoDocumentos(),
                Email = user.Email,
                Nombre = user.Nombre,
                Id =  user.Id,
                Apellidos = user.Apellidos,
                Telefono = user.PhoneNumber,
                TipoUsuario = user.TipoUsuario,
            };
        }
    }
}
