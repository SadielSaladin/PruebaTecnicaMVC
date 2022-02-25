using Fifa2022.DataContext;
using Fifa2022.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2022.Controllers
{
    public class EquiposController : Controller
    {
        private readonly AplicationDbContext _context;
        public EquiposController(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var aplicationDbContext = _context.Equipos.Include(e => e.Estado);
            return View(await aplicationDbContext.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["EstadoID"] = new SelectList(_context.Estados, "Id", "Nombre_Estado");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(equipo);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Algo salio mal{ex.Message}");


                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var equipo = _context.Equipos.Find(id);
            if (equipo == null)
            {
                return NotFound();
            }

            ViewData["EstadoID"] = new SelectList(_context.Estados, "Id", "Nombre_Estado", equipo.EstadoID);
            return View(equipo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Editar(Equipo equipo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipo);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Algo salio mal{ex.Message}");


                }
            }
            return View();
        }
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var equipo = _context.Equipos.Find(id);
            if (equipo == null)
            {
                return NotFound();
            }

            return View(equipo);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarEquipo(int? id)
        {
            var equipo = _context.Equipos.Find(id);

            if (equipo == null)
            {
                return NotFound();
            }
            try
            {
                _context.Remove(equipo);
                _context.SaveChanges();
                
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Algo salio mal{ex.Message}");
            }
            return RedirectToAction("Index");

        }
    }

   
}
