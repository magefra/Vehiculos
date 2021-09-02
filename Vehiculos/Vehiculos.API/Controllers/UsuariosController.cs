﻿using Microsoft.AspNetCore.Authorization;
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
    }
}
