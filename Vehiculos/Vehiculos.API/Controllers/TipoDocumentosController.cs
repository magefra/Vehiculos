using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data;
using Vehiculos.API.Data.Entities;

namespace Vehiculos.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class TipoDocumentosController : Controller
    {
        private readonly DataContext _context;

        public TipoDocumentosController(DataContext context)
        {
            _context = context;
        }


        // GET: VehiculoTipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoDocumentos.ToListAsync());
        }



        // GET: VehiculoTipos/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoDocumento tipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(tipo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento.");
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }


                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }
            }
            return View(tipo);
        }

        // GET: VehiculoTipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoDocumento tipo = await _context.TipoDocumentos.FindAsync(id);
            if (tipo == null)
            {
                return NotFound();
            }


            return View(tipo);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipoDocumento tipoDocumento)
        {
            if (id != tipoDocumento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDocumento);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de documento.");
                    }
                    else
                    {

                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }


                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                }


            }
            return View(tipoDocumento);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TipoDocumento tipo = await _context.TipoDocumentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipo == null)
            {
                return NotFound();
            }

            _context.TipoDocumentos.Remove(tipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
