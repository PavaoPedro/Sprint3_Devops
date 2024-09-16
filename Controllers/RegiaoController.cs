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
    public class RegiaoController : Controller
    {
        private readonly MAIDbContext _context;

        public RegiaoController(MAIDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regiao.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regiao.Include(x => x.Cidade)
                .FirstOrDefaultAsync(m => m.IdRegiao == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegiao,RegiaoNome")] Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regiao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regiao);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regiao.FindAsync(id);
            if (regiao == null)
            {
                return NotFound();
            }
            return View(regiao);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegiao,RegiaoNome")] Regiao regiao)
        {
            if (id != regiao.IdRegiao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regiao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegiaoExists(regiao.IdRegiao))
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
            return View(regiao);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regiao
                .FirstOrDefaultAsync(m => m.IdRegiao == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regiao = await _context.Regiao.FindAsync(id);
            if (regiao != null)
            {
                _context.Regiao.Remove(regiao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegiaoExists(int id)
        {
            return _context.Regiao.Any(e => e.IdRegiao == id);
        }
    }
}
