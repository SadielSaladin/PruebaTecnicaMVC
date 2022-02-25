using Fifa2022.DataContext;
using Fifa2022.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2022.Controllers
{
    public class EstadoController : Controller
    {
        private readonly AplicationDbContext _context;
        public EstadoController(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Estados.ToListAsync());
        }


        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Estado estado)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(estado);
                    _context.SaveChanges();
                    return RedirectToAction("Index","Home");
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

            var estado = _context.Estados.Find(id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarEstado(int? id)
        {
            var estado = _context.Estados.Find(id);

            if (estado== null)
            {
                return NotFound();
            }
            try
            {
                _context.Remove(estado);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Algo salio mal{ex.Message}");
            }
            return RedirectToAction("Index","Estado");

        }
    }
}