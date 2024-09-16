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
    public class LoginController : Controller
    {
        private readonly MAIDbContext _context;

        public LoginController(MAIDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Login.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Login
                .FirstOrDefaultAsync(m => m.IdLogin == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLogin,EmailLogin, Senha")] Login login)
        {
            if (ModelState.IsValid)
            {
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(login);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            return View(login);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLogin,EmailLogin, Senha")] Login login)
        {
            if (id != login.IdLogin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.IdLogin))
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
            return View(login);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.Login
                .FirstOrDefaultAsync(m => m.IdLogin == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var login = await _context.Login.FindAsync(id);
            if (login != null)
            {
                _context.Login.Remove(login);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.IdLogin == id);
        }
    }
}
