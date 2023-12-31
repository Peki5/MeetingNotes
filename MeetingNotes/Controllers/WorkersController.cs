﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingNotes.Data;
using MeetingNotes.Models;
using Microsoft.IdentityModel.Tokens;
using MeetingNotes.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using MeetingNotes.Models.ViewModels;

namespace MeetingNotes.Controllers
{
    public class WorkersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWorkerService _workerService;


        public WorkersController(ApplicationDbContext context, IWorkerService workerService)
        {
            _context = context;
            _workerService = workerService;
        }



        // GET: Workers
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            return View(_workerService.GetWorkers());

            //return _context.Workers != null ? 
            //            View(await _context.Workers.ToListAsync()) :
            //            Problem("Entity set 'ApplicationDbContext.Workers'  is null.");
        }

        // GET: Workers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            //var worker = await _context.Workers
            //.FirstOrDefaultAsync(m => m.WorkerId == id);
            var worker = _workerService.GetWorkerById(id);
            if (worker == null)
            {
                return NotFound();
            }

            return View(worker);
        }

        // GET: Workers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateWorkerModel worker)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(worker);
                //await _context.SaveChangesAsync();
                //_workerService.CreateWorker(worker);
                await _workerService.CreateWorkerModel(worker);

                return RedirectToAction(nameof(Index));
            }
            return View(worker);
        }

        // GET: Workers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            //var worker = await _context.Workers.FindAsync(id);
            var worker = _workerService.GetWorkerById(id);
            if (worker == null)
            {
                return NotFound();
            }
            return View(worker);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( Worker worker)
        {
            if (worker.WorkerId == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(worker);
                    //await _context.SaveChangesAsync();
                    _workerService.EditWorkerAsync(worker);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkerExists(worker.WorkerId))
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
            return View(worker);
        }

        // GET: Workers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            //var worker = await _context.Workers
            //.FirstOrDefaultAsync(m => m.WorkerId == id);
            var worker = _workerService.GetWorkerById(id);
            if (!WorkerExists(worker.WorkerId))
            {
                return NotFound();
            }

            return View(worker);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Workers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Workers'  is null.");
            }
            //var worker = await _context.Workers.FindAsync(id);
            //if (worker != null)
            //{
            //    _context.Workers.Remove(worker);
            //}
            _workerService.DeleteWorkerAsync(id);

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkerExists(int id)
        {
            //return (_context.Workers?.Any(e => e.WorkerId == id)).GetValueOrDefault();
            return _workerService.GetWorkerById(id) != null;
        }
    }
}
