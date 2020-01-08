using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventRegistration.Models;

namespace EventRegistration.Controllers
{
    public class UserEventController : Controller
    {
        private readonly ApplicationContext _context;

        public UserEventController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: UserEvent
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserEventRegistrations.ToListAsync());
        }

        // GET: UserEvent/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEventRegistration = await _context.UserEventRegistrations
                .FirstOrDefaultAsync(m => m.Email == id);
            if (userEventRegistration == null)
            {
                return NotFound();
            }

            return View(userEventRegistration);
        }

        // GET: UserEvent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserEvent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,Group,UniversityGraduationDate,Description,FullName,Phone,DateRegistraion,StatusRegistration")] UserEventRegistration userEventRegistration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userEventRegistration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userEventRegistration);
        }

        // GET: UserEvent/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEventRegistration = await _context.UserEventRegistrations.FindAsync(id);
            if (userEventRegistration == null)
            {
                return NotFound();
            }
            return View(userEventRegistration);
        }

        // POST: UserEvent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Email,Group,UniversityGraduationDate,Description,FullName,Phone,DateRegistraion,StatusRegistration")] UserEventRegistration userEventRegistration)
        {
            if (id != userEventRegistration.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userEventRegistration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserEventRegistrationExists(userEventRegistration.Email))
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
            return View(userEventRegistration);
        }

        // GET: UserEvent/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEventRegistration = await _context.UserEventRegistrations
                .FirstOrDefaultAsync(m => m.Email == id);
            if (userEventRegistration == null)
            {
                return NotFound();
            }

            return View(userEventRegistration);
        }

        // POST: UserEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userEventRegistration = await _context.UserEventRegistrations.FindAsync(id);
            _context.UserEventRegistrations.Remove(userEventRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEventRegistrationExists(string id)
        {
            return _context.UserEventRegistrations.Any(e => e.Email == id);
        }
    }
}
