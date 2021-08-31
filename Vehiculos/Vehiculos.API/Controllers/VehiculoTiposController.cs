using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vehiculos.API.Data;
using Vehiculos.API.Data.Entities;

namespace Vehiculos.API.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class VehiculoTiposController : Controller
    {
        private readonly DataContext _context;

        public VehiculoTiposController(DataContext context)
        {
            _context = context;
        }

        // GET: VehiculoTipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehiculosTipo.ToListAsync());
        }



        // GET: VehiculoTipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehiculoTipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehiculoTipo vehiculoTipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(vehiculoTipo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de vehículo.");
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
            return View(vehiculoTipo);
        }

        // GET: VehiculoTipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehiculoTipo vehiculoTipo = await _context.VehiculosTipo.FindAsync(id);
            if (vehiculoTipo == null)
            {
                return NotFound();
            }
            return View(vehiculoTipo);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehiculoTipo vehiculoTipo)
        {
            if (id != vehiculoTipo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehiculoTipo);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {

                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe este tipo de vehículo.");
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
            return View(vehiculoTipo);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehiculoTipo vehiculoTipo = await _context.VehiculosTipo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehiculoTipo == null)
            {
                return NotFound();
            }

            _context.VehiculosTipo.Remove(vehiculoTipo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }



    }
}
