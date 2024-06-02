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
            var ������� = await _context.�������.ToListAsync();
            return View(�������);
        }

        // GET: api/Home/GetClients
        public async Task<ActionResult<IEnumerable<������>>> GetClients()
        {
            return await _context.�������.ToListAsync();
        }

        // GET: Home/Details/5
        public async Task<ActionResult<������>> Details(int id)
        {
            var ������ = await _context.�������.FindAsync(id);
            if (������ == null)
            {
                return NotFound();
            }
            return View(������);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("���,�������,��������,������������")] ������ ������)
        {
            if (ModelState.IsValid)
            {
                _context.Add(������);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(������);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var ������ = await _context.�������.FindAsync(id);
            if (������ == null)
            {
                return NotFound();
            }
            return View(������);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("������ID,���,�������,��������,������������")] ������ ������)
        {
            if (id != ������.ID_�������)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(������);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!������Exists(������.ID_�������))
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
            return View(������);
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var ������ = await _context.�������.FindAsync(id);
            if (������ == null)
            {
                return NotFound();
            }
            return View(������);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var ������ = await _context.�������.FindAsync(id);
            _context.�������.Remove(������);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ������Exists(int id)
        {
            return _context.�������.Any(e => e.ID_������� == id);
        }
    }
}
