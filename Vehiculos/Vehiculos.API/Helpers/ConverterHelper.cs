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
                Id = user.Id,
                IdImagen = user.IdImagen,
                Apellidos = user.Apellidos,
                Telefono = user.PhoneNumber,
                TipoUsuario = user.TipoUsuario,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="imageId"></param>
        /// <param name="isNew"></param>
        /// <returns></returns>
        public async Task<Vehiculo> ToVehiculoAsync(VehiculoViewModel model, bool isNew)
        {
            return new Vehiculo
            {

                Marca = await _context.Marcas.FindAsync(model.idMarca),
                Color = model.Color,
                Id = isNew ? 0 : model.Id,
                Linea = model.Linea,
                Modelo = model.Modelo,
                Placa =  model.Placa.ToUpper(),
                Observacion = model.Observacion,
                TipoVehiculo = await _context.VehiculosTipo.FindAsync(model.IdTipoVehiculo)
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehiculo"></param>
        /// <returns></returns>
        public VehiculoViewModel ToVehiculoViewModel(Vehiculo vehiculo)
        {
            return new VehiculoViewModel
            {
                idMarca = vehiculo.Marca.Id,
                Marcas = _combosHelper.GetCombosMarcas(),
                Color = vehiculo.Color,
                Id = vehiculo.Id,
                Linea = vehiculo.Linea,
                Modelo = vehiculo.Modelo,
                Placa = vehiculo.Placa,
                Observacion = vehiculo.Observacion,
                IdUsuario = vehiculo.Usuario.Id,



            };      
        
        }
    }
}
