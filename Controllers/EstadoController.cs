using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MAI.Models;
using MAI.Persistencia;

namespace MAI.Controllers
{
    public class EstadoController : Controller
    {
        private readonly MAIDbContext _context;

        public EstadoController(MAIDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estado.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Estado
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }



        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstado,EstadoNome,Sigla")] Estado estado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }
            return View(estado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstado,EstadoNome,Sigla")] Estado estado)
        {
            if (id != estado.IdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoExists(estado.IdEstado))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estado);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estado = await _context.Estado
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estado == null)
            {
                return NotFound();
            }

            return View(estado);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estado = await _context.Estado.FindAsync(id);
            if (estado != null)
            {
                _context.Estado.Remove(estado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoExists(int id)
        {
            return _context.Estado.Any(e => e.IdEstado == id);
        }
    }
}
