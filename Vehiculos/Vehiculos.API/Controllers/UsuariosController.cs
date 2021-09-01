using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data;
using Vehiculos.Common.Enums;

namespace Vehiculos.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController: Controller
    {
        private readonly DataContext _dataContext;

        public UsuariosController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Usuarios
                .Include(x => x.TipoDocumento)
                .Include(x => x.Vehiculos)
                .Where(x => x.TipoUsuario == TipoUsuario.Usuario)
                .ToListAsync());
        }
    }
}
