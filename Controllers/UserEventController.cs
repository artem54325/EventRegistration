using ClosedXML.Excel;
using EventRegistration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEventRegistration = await _context.UserEventRegistrations
                .FirstOrDefaultAsync(m => m.ID == id);
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
        public async Task<IActionResult> Create([Bind("ID,Email,Group,UniversityGraduationDate,Description,FullName,Phone,DateRegistraion,StatusRegistration")] UserEventRegistration userEventRegistration)
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
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,Group,UniversityGraduationDate,Description,FullName,Phone,DateRegistraion,StatusRegistration")] UserEventRegistration userEventRegistration)
        {
            if (id != userEventRegistration.ID)
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
                    if (!UserEventRegistrationExists(userEventRegistration.ID))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userEventRegistration = await _context.UserEventRegistrations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userEventRegistration == null)
            {
                return NotFound();
            }

            return View(userEventRegistration);
        }

        // POST: UserEvent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userEventRegistration = await _context.UserEventRegistrations.FindAsync(id);
            _context.UserEventRegistrations.Remove(userEventRegistration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserEventRegistrationExists(int id)
        {
            return _context.UserEventRegistrations.Any(e => e.ID == id);
        }

        [HttpPost]
        public FileResult Export()
        {
            DataTable dt = getData();
            //Name of File  
            string fileName = "Sample.xlsx";
            using (XLWorkbook wb = new XLWorkbook())
            {
                //Add DataTable in worksheet  
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    //Return xlsx Excel File  
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
                }
            }
        }

        public DataTable getData()
        {
            //Creating DataTable  
            DataTable dt = new DataTable();
            //Setiing Table Name  
            dt.TableName = "EmployeeData";
            //Add Columns  
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("City", typeof(string));
            //Add Rows in DataTable  
            dt.Rows.Add(1, "Anoop Kumar Sharma", "Delhi");
            dt.Rows.Add(2, "Andrew", "U.P.");
            dt.AcceptChanges();
            return dt;
        }
    }
}
