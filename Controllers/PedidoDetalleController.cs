using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebInfinityNetCore.Models;

namespace WebInfinityNetCore.Controllers
{
    public class PedidoDetalleController : Controller
    {
        private readonly FinalContext _context;

        public PedidoDetalleController(FinalContext context)
        {
            _context = context;
        }

        // GET: PedidoDetalle
        public async Task<IActionResult> Index()
        {
            var finalContext = _context.PedidoDetalles.Include(p => p.IdPedidoNavigation).Include(p => p.IdProductoNavigation);
            return View(await finalContext.ToListAsync());
        }

        // GET: PedidoDetalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDetalle = await _context.PedidoDetalles
                .Include(p => p.IdPedidoNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoDetalle == null)
            {
                return NotFound();
            }

            return View(pedidoDetalle);
        }

        // GET: PedidoDetalle/Create
        public IActionResult Create()
        {
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "Id", "Id");
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreDelPlato");
            return View();
        }

        // POST: PedidoDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cantidad,PrecioUnitario,Total,IdPedido,IdProducto,UsuarioRegistro,FechaRegistro,RegistroActivo")] PedidoDetalle pedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedidoDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "Id", "Id", pedidoDetalle.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreDelPlato", pedidoDetalle.IdProducto);
            return View(pedidoDetalle);
        }

        // GET: PedidoDetalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDetalle = await _context.PedidoDetalles.FindAsync(id);
            if (pedidoDetalle == null)
            {
                return NotFound();
            }
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "Id", "Id", pedidoDetalle.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreDelPlato", pedidoDetalle.IdProducto);
            return View(pedidoDetalle);
        }

        // POST: PedidoDetalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,PrecioUnitario,Total,IdPedido,IdProducto,UsuarioRegistro,FechaRegistro,RegistroActivo")] PedidoDetalle pedidoDetalle)
        {
            if (id != pedidoDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoDetalleExists(pedidoDetalle.Id))
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
            ViewData["IdPedido"] = new SelectList(_context.Pedidos, "Id", "Id", pedidoDetalle.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.Productos, "Id", "NombreDelPlato", pedidoDetalle.IdProducto);
            return View(pedidoDetalle);
        }

        // GET: PedidoDetalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoDetalle = await _context.PedidoDetalles
                .Include(p => p.IdPedidoNavigation)
                .Include(p => p.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedidoDetalle == null)
            {
                return NotFound();
            }

            return View(pedidoDetalle);
        }

        // POST: PedidoDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedidoDetalle = await _context.PedidoDetalles.FindAsync(id);
            _context.PedidoDetalles.Remove(pedidoDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoDetalleExists(int id)
        {
            return _context.PedidoDetalles.Any(e => e.Id == id);
        }
    }
}
