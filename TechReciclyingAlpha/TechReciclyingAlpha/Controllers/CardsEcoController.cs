using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechReciclyingAlpha.Models;

namespace TechReciclyingAlpha.Controllers
{
    public class CardsEcoController : Controller
    {
        private readonly Contexto _context;

        public CardsEcoController(Contexto context)
        {
            _context = context;
        }

        // GET: CardsEco
        public async Task<IActionResult> Index()
        {
              return _context.Ecoponto != null ? 
                          View(await _context.Ecoponto.ToListAsync()) :
                          Problem("Entity set 'Contexto.Ecoponto'  is null.");
        }

        private bool EcopontoExists(int id)
        {
          return (_context.Ecoponto?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}
