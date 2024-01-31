using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoBD.Models;

namespace proyectoBD.Controllers
{
    public class FormaDePagoesController : Controller
    {
        private readonly ProyectoBdContext _context;

        public FormaDePagoesController(ProyectoBdContext context)
        {
            _context = context;
        }

        // GET: FormaDePagoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormaDePagos.ToListAsync());
        }

        // GET: FormaDePagoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaDePago = await _context.FormaDePagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaDePago == null)
            {
                return NotFound();
            }

            return View(formaDePago);
        }

        // GET: FormaDePagoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormaDePagoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoPago,Nombre")] FormaDePago formaDePago)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formaDePago);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formaDePago);
        }

        // GET: FormaDePagoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaDePago = await _context.FormaDePagos.FindAsync(id);
            if (formaDePago == null)
            {
                return NotFound();
            }
            return View(formaDePago);
        }

        // POST: FormaDePagoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoPago,Nombre")] FormaDePago formaDePago)
        {
            if (id != formaDePago.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formaDePago);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormaDePagoExists(formaDePago.Id))
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
            return View(formaDePago);
        }

        // GET: FormaDePagoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formaDePago = await _context.FormaDePagos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formaDePago == null)
            {
                return NotFound();
            }

            return View(formaDePago);
        }

        // POST: FormaDePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formaDePago = await _context.FormaDePagos.FindAsync(id);
            if (formaDePago != null)
            {
                _context.FormaDePagos.Remove(formaDePago);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormaDePagoExists(int id)
        {
            return _context.FormaDePagos.Any(e => e.Id == id);
        }
    }
}
