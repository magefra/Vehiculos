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
    [Authorize(Roles ="Administrador")]
    public class MarcasController : Controller
    {

        private readonly DataContext _context;

        public MarcasController(DataContext context)
        {
            _context = context;
        }

        // GET: VehiculoTipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Marcas.ToListAsync());
        }



        // GET: VehiculoTipos/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Marca marca)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(marca);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe esa marca.");
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
            return View(marca);
        }

        // GET: VehiculoTipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Marca marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }


            return View(marca);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Marca marca)
        {
            if (id != marca.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marca);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe esta marca.");
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
            return View(marca);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Marca marca = await _context.Marcas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}
