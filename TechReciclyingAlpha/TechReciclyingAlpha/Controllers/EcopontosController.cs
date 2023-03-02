﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechReciclyingAlpha.Filters;
using TechReciclyingAlpha.Models;

namespace TechReciclyingAlpha.Controllers
{
    //[PaginaRestritaAdmin]
    //[PaginaParaUsuarioLogado]

    public class EcopontosController : Controller
    {
        private readonly Contexto _context;

        public EcopontosController(Contexto context)
        {
            _context = context;
        }

        // GET: Ecopontos
        public async Task<IActionResult> Index()
        {
              return _context.Ecoponto != null ? 
                          View(await _context.Ecoponto.ToListAsync()) :
                          Problem("Entity set 'Contexto.Ecoponto'  is null."); 
        }

        // GET: Ecopontos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ecoponto == null)
            {
                return NotFound();
            }

            var ecoponto = await _context.Ecoponto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecoponto == null)
            {
                return NotFound();
            }

            return View(ecoponto);
        }

        // GET: Ecopontos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ecopontos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,WebSite,Endereco,Telefone,Latitude,Longitude,Descricao,Foto")] Ecoponto ecoponto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ecoponto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ecoponto);
        }

        // GET: Ecopontos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ecoponto == null)
            {
                return NotFound();
            }

            var ecoponto = await _context.Ecoponto.FindAsync(id);
            if (ecoponto == null)
            {
                return NotFound();
            }
            return View(ecoponto);
        }

        // POST: Ecopontos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,WebSite,Endereco,Telefone,Latitude,Longitude,Descricao,Foto")] Ecoponto ecoponto)
        {
            if (id != ecoponto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ecoponto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EcopontoExists(ecoponto.Id))
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
            return View(ecoponto);
        }

        // GET: Ecopontos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ecoponto == null)
            {
                return NotFound();
            }

            var ecoponto = await _context.Ecoponto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ecoponto == null)
            {
                return NotFound();
            }

            return View(ecoponto);
        }

        // POST: Ecopontos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ecoponto == null)
            {
                return Problem("Entity set 'Contexto.Ecoponto'  is null.");
            }
            var ecoponto = await _context.Ecoponto.FindAsync(id);
            if (ecoponto != null)
            {
                _context.Ecoponto.Remove(ecoponto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EcopontoExists(int id)
        {
          return (_context.Ecoponto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
