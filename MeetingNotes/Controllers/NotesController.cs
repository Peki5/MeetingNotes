using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingNotes.Data;
using MeetingNotes.Models;
using MeetingNotes.Services;

namespace MeetingNotes.Controllers
{
    public class NotesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly INotesService _noteService;

        public NotesController(ApplicationDbContext context, INotesService notesService)
        {
            _context = context;
            _noteService = notesService;
        }

        // GET: Notes
        public async Task<IActionResult> Index()
        {
              //return _context.Notes != null ? 
              //            View(await _context.Notes.ToListAsync()) :
              //            Problem("Entity set 'ApplicationDbContext.Notes'  is null.");
              return View(_noteService.GetNotes());
        }

        // GET: Notes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            //var notes = await _context.Notes
            //    .FirstOrDefaultAsync(m => m.NotesId == id);
            var notes = _noteService.GetNoteById(id);    
            if (notes == null)
            {
                return NotFound();
            }

            return View(notes);
        }

        // GET: Notes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NotesId,NotesText")] Notes notes)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(notes);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                _noteService.CreateNote(notes);
                return RedirectToAction(nameof(Index));
            }
            return View(notes);
        }

        // GET: Notes/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            //var notes = await _context.Notes.FindAsync(id);
            var notes = _noteService.GetNoteById(id);
            if (!NotesExists(notes.NotesId))
            {
                return NotFound();
            }
            return View(notes);
        }

        // POST: Notes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("NotesId,NotesText")] Notes notes)
        {
            if (notes.NotesId==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(notes);
                    //await _context.SaveChangesAsync();
                    _noteService.EditNote(notes);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotesExists(notes.NotesId))
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
            return View(notes);
        }

        // GET: Notes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            //var notes = await _context.Notes
            //    .FirstOrDefaultAsync(m => m.NotesId == id);
            var notes = _noteService.GetNoteById(id);
            if (notes == null)
            {
                return NotFound();
            }

            return View(notes);
        }

        // POST: Notes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Notes'  is null.");
            }
            //var notes = await _context.Notes.FindAsync(id);
            _noteService.DeleteNote(id);
            //if (notes != null)
            //{
            //    _context.Notes.Remove(notes);
            //}
            
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotesExists(int id)
        {
            //return (_context.Notes?.Any(e => e.NotesId == id)).GetValueOrDefault();
            return _noteService.GetNoteById(id) != null;
        }
    }
}
