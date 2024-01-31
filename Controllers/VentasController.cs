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
    public class VentasController : Controller
    {
        private readonly ProyectoBdContext _context;

        public VentasController(ProyectoBdContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var proyectoBdContext = _context.Ventas.Include(v => v.IdClienteNavigation).Include(v => v.IdEmpleadoNavigation).Include(v => v.IdFormaDePagoNavigation);
            return View(await proyectoBdContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdEmpleadoNavigation)
                .Include(v => v.IdFormaDePagoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id");
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Id");
            ViewData["IdFormaDePago"] = new SelectList(_context.FormaDePagos, "Id", "Id");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,IdCliente,IdEmpleado,IdFormaDePago")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", venta.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Id", venta.IdEmpleado);
            ViewData["IdFormaDePago"] = new SelectList(_context.FormaDePagos, "Id", "Id", venta.IdFormaDePago);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", venta.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Id", venta.IdEmpleado);
            ViewData["IdFormaDePago"] = new SelectList(_context.FormaDePagos, "Id", "Id", venta.IdFormaDePago);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,IdCliente,IdEmpleado,IdFormaDePago")] Venta venta)
        {
            if (id != venta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaExists(venta.Id))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id", "Id", venta.IdCliente);
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "Id", "Id", venta.IdEmpleado);
            ViewData["IdFormaDePago"] = new SelectList(_context.FormaDePagos, "Id", "Id", venta.IdFormaDePago);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venta = await _context.Ventas
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdEmpleadoNavigation)
                .Include(v => v.IdFormaDePagoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (venta == null)
            {
                return NotFound();
            }

            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}
