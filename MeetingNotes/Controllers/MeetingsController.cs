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
    public class MeetingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMeetingService _meetingService;
        private readonly INotesService _notesService;

        public MeetingsController(ApplicationDbContext context, INotesService notesService, IMeetingService meetingService)
        {
            _context = context;
            _notesService = notesService;
            _meetingService = meetingService;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
              //return _context.Meetings != null ? 
              //            View(await _context.Meetings.ToListAsync()) :
              //            Problem("Entity set 'ApplicationDbContext.Meetings'  is null.");
              return View(_meetingService.GetMeetings());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            //var meeting = await _context.Meetings
            //    .FirstOrDefaultAsync(m => m.MeetingId == id);
            var meeting = _meetingService.GetMeetingById(id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(meeting);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                _meetingService.CreateMeeting(meeting);
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            //var meeting = await _context.Meetings.FindAsync(id);
            var meeting = _meetingService.GetMeetingById(id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Meeting meeting)
        {
            if (meeting.MeetingId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(meeting);
                    //await _context.SaveChangesAsync();
                    _meetingService.EditMeeting(meeting);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.MeetingId))
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
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            //var meeting = await _context.Meetings
            //    .FirstOrDefaultAsync(m => m.MeetingId == id);
            var meeting = _meetingService.GetMeetingById(id); 
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Meetings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Meetings'  is null.");
            }
            //var meeting = await _context.Meetings.FindAsync(id);
            //if (meeting != null)
            //{
            //    _context.Meetings.Remove(meeting);
            //}
            _meetingService.DeleteMeeting(id);
            //var meeting = _meetingService.GetMeetingById(id);
            //_notesService.DeleteNote(meeting.notes.NotesId);//ako brisem meeting brisem i njegov notes
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
          //return (_context.Meetings?.Any(e => e.MeetingId == id)).GetValueOrDefault();
          return _meetingService.GetMeetingById(id) != null;
        }
    }
}
