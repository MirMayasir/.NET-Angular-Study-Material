using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstMVCproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCproject.Controllers
{
    public class AccountDetailsController : Controller
    {
        private readonly BankdatabaseContext _context;

        public AccountDetailsController(BankdatabaseContext context)
        {
            _context = context;
        }

        // GET: AccountDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountDetails.ToListAsync());
        }

        // GET: AccountDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountDetail = await _context.AccountDetails
                .FirstOrDefaultAsync(m => m.Anumber == id);
            if (accountDetail == null)
            {
                return NotFound();
            }

            return View(accountDetail);
        }

        // GET: AccountDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Anumber,Aname,Aaddress,Abalance")] AccountDetail accountDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountDetail);
        }

        // GET: AccountDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountDetail = await _context.AccountDetails.FindAsync(id);
            if (accountDetail == null)
            {
                return NotFound();
            }
            return View(accountDetail);
        }

        // POST: AccountDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Anumber,Aname,Aaddress,Abalance")] AccountDetail accountDetail)
        {
            if (id != accountDetail.Anumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountDetailExists(accountDetail.Anumber))
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
            return View(accountDetail);
        }

        // GET: AccountDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountDetail = await _context.AccountDetails
                .FirstOrDefaultAsync(m => m.Anumber == id);
            if (accountDetail == null)
            {
                return NotFound();
            }

            return View(accountDetail);
        }

        // POST: AccountDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var accountDetail = await _context.AccountDetails.FindAsync(id);
            if (accountDetail != null)
            {
                _context.AccountDetails.Remove(accountDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountDetailExists(string id)
        {
            return _context.AccountDetails.Any(e => e.Anumber == id);
        }
    }
}
