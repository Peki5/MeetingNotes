using System;
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
using MeetingManager.Services;

namespace MeetingNotes.Controllers
{
    public class ManagersController : Controller
    {
        private readonly ApplicationDbContext _context;  
        private readonly IManagerService _managerService;


        public ManagersController(ApplicationDbContext context, IManagerService managerService)
        {
            _context = context;
            _managerService = managerService;
        }



        // GET: Workers
        //[Authorize]
        public async Task<IActionResult> Index()
        {
            return View(_managerService.GetAllManagersViewModel());
        }

        // GET: Workers/Create
        public async Task<IActionResult> Create()
        {
            return View(_managerService.GetAllManagersViewModel());
        }



        // POST: Workers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateManagerModel manager)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(worker);
                //await _context.SaveChangesAsync();
                //_workerService.CreateWorker(worker);
                await _managerService.CreateManagerModel(manager);

                return RedirectToAction(nameof(Index));
            }
            return View(manager);
        }
    }
}
