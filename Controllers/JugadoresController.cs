using Fifa2022.DataContext;
using Fifa2022.Models;
using Fifa2022.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2022.Controllers
{
    public class JugadoresController : Controller
    {
        private readonly AplicationDbContext _context;
        public JugadoresController(AplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var aplicationDbContext = _context.Jugadores.Include(j => j.Estado);
            return View(aplicationDbContext);
        }

        public IActionResult Estado()
        {
            List<string> estados = new List<string>();
            IEnumerable<Estado> listEstado = _context.Estados;
            IEnumerable<Jugador> listjugadores = _context.Jugadores.Include(x=> x.Estado_id);
            foreach(Jugador j in listjugadores)
            {
                foreach (Estado c in listEstado)
                {
                    estados.Add(j.Nombre + c.Nombre_Estado);
                }

               
            }
            return View(estados);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewData["EstadoID"] = new SelectList(_context.Estados, "Id", "Nombre_Estado");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(jugador);
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

            var jugador = _context.Jugadores.Find(id);
            if (jugador == null)
            {
                return NotFound();
            }
            ViewData["Estado_id"] = new SelectList(_context.Estados, "Id", "Nombre_Estado", jugador.Estado_id);

            return View(jugador);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jugador);
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

            var jugador = _context.Jugadores.Find(id);
            if (jugador == null)
            {
                return NotFound();
            }

            return View(jugador);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarJugador(int? id)
        {
            var jugador = _context.Jugadores.Find(id);

            if (jugador== null)
            {
                return NotFound();
            }
            try
            {
                _context.Remove(jugador);
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

