using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankContext _context;

        public HomeController(BankContext context)
        {
            _context = context;
        }

        // GET: Home/Index
        public async Task<ActionResult> Index()
        {
            var клиенты = await _context.Клиенты.ToListAsync();
            return View(клиенты);
        }

        // GET: api/Home/GetClients
        public async Task<ActionResult<IEnumerable<Клиент>>> GetClients()
        {
            return await _context.Клиенты.ToListAsync();
        }

        // GET: Home/Details/5
        public async Task<ActionResult<Клиент>> Details(int id)
        {
            var клиент = await _context.Клиенты.FindAsync(id);
            if (клиент == null)
            {
                return NotFound();
            }
            return View(клиент);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Имя,Фамилия,Отчество,ДатаРождения")] Клиент клиент)
        {
            if (ModelState.IsValid)
            {
                _context.Add(клиент);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(клиент);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var клиент = await _context.Клиенты.FindAsync(id);
            if (клиент == null)
            {
                return NotFound();
            }
            return View(клиент);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("КлиентID,Имя,Фамилия,Отчество,ДатаРождения")] Клиент клиент)
        {
            if (id != клиент.ID_Клиента)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(клиент);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!КлиентExists(клиент.ID_Клиента))
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
            return View(клиент);
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var клиент = await _context.Клиенты.FindAsync(id);
            if (клиент == null)
            {
                return NotFound();
            }
            return View(клиент);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var клиент = await _context.Клиенты.FindAsync(id);
            _context.Клиенты.Remove(клиент);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool КлиентExists(int id)
        {
            return _context.Клиенты.Any(e => e.ID_Клиента == id);
        }
    }
}
