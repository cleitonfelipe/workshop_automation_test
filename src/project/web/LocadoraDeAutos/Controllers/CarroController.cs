using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocadoraDeAutos.Data;
using LocadoraDeAutos.Models;

namespace LocadoraDeAutos.Controllers
{
    public class CarroController : Controller
    {
        private readonly LocadoraDeAutosContext _context;

        public CarroController(LocadoraDeAutosContext context)
        {
            _context = context;
        }

        // GET: Carro
        public async Task<IActionResult> Index()
        {
            return View(await _context.Carro.ToListAsync());
        }

        // GET: Carro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroViewModel = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroViewModel == null)
            {
                return NotFound();
            }

            return View(carroViewModel);
        }

        // GET: Carro/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Modelo,Marca,Preco")] CarroViewModel carroViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carroViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carroViewModel);
        }

        // GET: Carro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroViewModel = await _context.Carro.FindAsync(id);
            if (carroViewModel == null)
            {
                return NotFound();
            }
            return View(carroViewModel);
        }

        // POST: Carro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Modelo,Marca,Preco")] CarroViewModel carroViewModel)
        {
            if (id != carroViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carroViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroViewModelExists(carroViewModel.Id))
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
            return View(carroViewModel);
        }

        // GET: Carro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carroViewModel = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carroViewModel == null)
            {
                return NotFound();
            }

            return View(carroViewModel);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carroViewModel = await _context.Carro.FindAsync(id);
            _context.Carro.Remove(carroViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarroViewModelExists(int id)
        {
            return _context.Carro.Any(e => e.Id == id);
        }
    }
}
