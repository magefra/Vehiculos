using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data;
using Vehiculos.API.Data.Entities;
using Vehiculos.API.Helpers;
using Vehiculos.API.Models;
using Vehiculos.Common.Enums;

namespace Vehiculos.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IUsuarioHelper _usuarioHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IBlobHelper _blobHelper;
        private readonly IConverterHelper _converterHelper;

        public UsuariosController(DataContext dataContext,
                                  IUsuarioHelper usuarioHelper,
                                  ICombosHelper combosHelper,
                                  IBlobHelper blobHelper,
                                  IConverterHelper converterHelper)
        {
            _dataContext = dataContext;
            _usuarioHelper = usuarioHelper;
            _combosHelper = combosHelper;
            _blobHelper = blobHelper;
            _converterHelper = converterHelper;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Usuarios
                .Include(x => x.TipoDocumento)
                .Include(x => x.Vehiculos)
                .Where(x => x.TipoUsuario == TipoUsuario.Usuario)
                .ToListAsync());
        }


        public IActionResult Create()
        {
            UsuarioViewModel model = new UsuarioViewModel
            {
                TipoDocumentos = _combosHelper.GetCombosTipoDocumentos()
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioViewModel model)
        {



            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;

                if (model.ImagenFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImagenFile, "usuarios");
                }

                Usuario user = await _converterHelper.ToUserAsync(model, imageId, true);
                user.TipoUsuario = TipoUsuario.Usuario;

                await _usuarioHelper.AddUserAsync(user, "123456");
                await _usuarioHelper.AddUserToRoleAsync(user, user.TipoUsuario.ToString());


                return RedirectToAction(nameof(Index));
            }


            model.TipoDocumentos = _combosHelper.GetCombosTipoDocumentos();
            return View(model);
        }



        // GET: VehiculoTipos/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            Usuario usuario = await _usuarioHelper.GetUserAsync(Guid.Parse(id));
            if (usuario == null)
            {
                return NotFound();
            }

            UsuarioViewModel model = _converterHelper.ToUserViewModel(usuario);


            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsuarioViewModel model)
        {

            if (ModelState.IsValid)
            {


                Guid imageId = model.IdImagen;
                if (model.ImagenFile != null)
                {
                    imageId = await _blobHelper.UploadBlobAsync(model.ImagenFile, "usuarios");
                }


                Usuario usuario = await _converterHelper.ToUserAsync(model, imageId, false);


                await _usuarioHelper.UpdateUserAsync(usuario);

                return RedirectToAction(nameof(Index));


            }


            model.TipoDocumentos = _combosHelper.GetCombosTipoDocumentos();
            return View(model);
        }


        public async Task<IActionResult> Delete(string? id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            Usuario usuario = await _usuarioHelper.GetUserAsync(Guid.Parse(id));
            if (usuario == null)
            {
                return NotFound();
            }

            await _usuarioHelper.DeleteUserAsync(usuario);


            await _blobHelper.DeleteBlobAsync(usuario.IdImagen, "usuarios");


            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            Usuario user = await _dataContext.Usuarios
                .Include(x => x.TipoDocumento)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.Marca)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.TipoVehiculo)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.VehiculoFotos)
                .Include(x => x.Vehiculos)
                .ThenInclude(x => x.Historias)
                .FirstOrDefaultAsync(x => x.Id == id);

            if(user == null)
            {
                return NotFound();
            }


            return View(user);


        }




    }
}
