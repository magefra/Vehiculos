using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data.Entities;
using Vehiculos.API.Helpers;
using Vehiculos.Common.Enums;

namespace Vehiculos.API.Data
{
    public class SeeDB
    {
        private readonly DataContext _context;
        private readonly IUsuarioHelper _usuarioHelper;

        public SeeDB(DataContext context, IUsuarioHelper usuarioHelper)
        {
            _context = context;
            _usuarioHelper = usuarioHelper;
        }

        public async Task SeedAsync()
        {
            // crea la base datos no exista la crea.
            // si tienes migraciones pendientes la va crear. 
            // si la base de datos existe y no hay migraciones no hace nada.
            await _context.Database.EnsureCreatedAsync();

            await CheckTipoVehiculoAsync();
            await CheckMarcasAsync();
            await CheckTipoDocumentoAsync();
            await CheckProcedemientoAsync();
            await CheckRolesAsycn();
            await CheckUserAsync("1010", "Magdiel", "Palacios", "magefra9@hotmail.com", "311 322 4620", "Calle Luna Calle Sol", TipoUsuario.Administrador);
            await CheckUserAsync("2020", "Benjamin", "Palacios", "benjamin@hotmail.com", "311 322 4620", "Calle Luna Calle Sol", TipoUsuario.Usuario);
        }






        private async Task CheckUserAsync(string document, string firstName, string lastName, string email, string phoneNumber, string address, TipoUsuario userType)
        {
            Usuario user = await _usuarioHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new Usuario
                {
                    Direccion = address,
                    Documento = document,
                    TipoDocumento = _context.TipoDocumentos.FirstOrDefault(x => x.Descripcion == "Cédula"),
                    Email = email,
                    Nombre = firstName,
                    Apellidos = lastName,
                    PhoneNumber = phoneNumber,
                    UserName = email,
                    TipoUsuario = userType
                };

                await _usuarioHelper.AddUserAsync(user, "123456");
                await _usuarioHelper.AddUserToRoleAsync(user, userType.ToString());

                //string token = await _usuarioHelper.GenerateEmailConfirmationTokenAsync(user);
                //await _usuarioHelper.ConfirmEmailAsync(user, token);
            }
        }



        private async Task CheckRolesAsycn()
        {
            await _usuarioHelper.CheckRoleAsync(TipoUsuario.Administrador.ToString());
            await _usuarioHelper.CheckRoleAsync(TipoUsuario.Usuario.ToString());
        }


        private async Task CheckProcedemientoAsync()
        {
            if (!_context.Procedimientos.Any())
            {
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Alineación" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Lubricación de suspención delantera" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Lubricación de suspención trasera" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Frenos delanteros" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Frenos traseros" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Líquido frenos delanteros" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Líquido frenos traseros" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Calibración de válvulas" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Alineación carburador" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Aceite motor" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Aceite caja" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Filtro de aire" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Sistema eléctrico" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Guayas" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Cambio llanta delantera" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Cambio llanta trasera" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Reparación de motor" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Kit arrastre" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Banda transmisión" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Cambio batería" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Lavado sistema de inyección" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Lavada de tanque" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Cambio de bujia" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Cambio rodamiento delantero" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Cambio rodamiento trasero" });
                _context.Procedimientos.Add(new Procedimiento { Precio = 10000, Descripcion = "Accesorios" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckTipoDocumentoAsync()
        {
            if (!_context.TipoDocumentos.Any())
            {
                _context.TipoDocumentos.Add(new Entities.TipoDocumento
                {
                    Descripcion = "Cédula"
                });

                _context.TipoDocumentos.Add(new Entities.TipoDocumento
                {
                    Descripcion = "Tarjeta de identidad"
                });

                _context.TipoDocumentos.Add(new Entities.TipoDocumento
                {
                    Descripcion = "NIT"
                });


                _context.TipoDocumentos.Add(new Entities.TipoDocumento
                {
                    Descripcion = "Pasaporte"
                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckMarcasAsync()
        {
            if (!_context.Marcas.Any())
            {
                _context.Marcas.Add(new Marca { Descripcion = "Ducati" });
                _context.Marcas.Add(new Marca { Descripcion = "Harley Davidson" });
                _context.Marcas.Add(new Marca { Descripcion = "KTM" });
                _context.Marcas.Add(new Marca { Descripcion = "BMW" });
                _context.Marcas.Add(new Marca { Descripcion = "Triumph" });
                _context.Marcas.Add(new Marca { Descripcion = "Victoria" });
                _context.Marcas.Add(new Marca { Descripcion = "Honda" });
                _context.Marcas.Add(new Marca { Descripcion = "Suzuki" });
                _context.Marcas.Add(new Marca { Descripcion = "Kawasaky" });
                _context.Marcas.Add(new Marca { Descripcion = "TVS" });
                _context.Marcas.Add(new Marca { Descripcion = "Bajaj" });
                _context.Marcas.Add(new Marca { Descripcion = "AKT" });
                _context.Marcas.Add(new Marca { Descripcion = "Yamaha" });
                _context.Marcas.Add(new Marca { Descripcion = "Chevrolet" });
                _context.Marcas.Add(new Marca { Descripcion = "Mazda" });
                _context.Marcas.Add(new Marca { Descripcion = "Renault" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckTipoVehiculoAsync()
        {
            if(!_context.VehiculosTipo.Any())
            {
                _context.VehiculosTipo.Add(new Entities.VehiculoTipo
                {
                    Descripcion = "Carro"
                });

                _context.VehiculosTipo.Add(new Entities.VehiculoTipo
                {
                    Descripcion = "Moto"
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
