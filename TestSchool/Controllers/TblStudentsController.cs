using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestSchool.Models;

namespace TestSchool.Controllers
{
    public class TblStudentsController : Controller
    {
        private readonly MySchoolContext _context;

        public TblStudentsController(MySchoolContext context)
        {
            _context = context;
        }

        // GET: TblStudents
        public async Task<IActionResult> Index()
        {
              return _context.TblStudents != null ? 
                          View(await _context.TblStudents.ToListAsync()) :
                          Problem("Entity set 'MySchoolContext.TblStudents'  is null.");
        }

        // GET: TblStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblStudents == null)
            {
                return NotFound();
            }

            var tblStudent = await _context.TblStudents
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (tblStudent == null)
            {
                return NotFound();
            }

            return View(tblStudent);
        }

        // GET: TblStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,Contact,ClassId,CityId,IsActive")] TblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblStudent);
        }

        // GET: TblStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblStudents == null)
            {
                return NotFound();
            }

            var tblStudent = await _context.TblStudents.FindAsync(id);
            if (tblStudent == null)
            {
                return NotFound();
            }
            return View(tblStudent);
        }

        // POST: TblStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,Contact,ClassId,CityId,IsActive")] TblStudent tblStudent)
        {
            if (id != tblStudent.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblStudentExists(tblStudent.StudentId))
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
            return View(tblStudent);
        }

        // GET: TblStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblStudents == null)
            {
                return NotFound();
            }

            var tblStudent = await _context.TblStudents
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (tblStudent == null)
            {
                return NotFound();
            }

            return View(tblStudent);
        }

        // POST: TblStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblStudents == null)
            {
                return Problem("Entity set 'MySchoolContext.TblStudents'  is null.");
            }
            var tblStudent = await _context.TblStudents.FindAsync(id);
            if (tblStudent != null)
            {
                _context.TblStudents.Remove(tblStudent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblStudentExists(int id)
        {
          return (_context.TblStudents?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
