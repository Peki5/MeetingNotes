using MeetingNotes.Data;
using MeetingNotes.Models;
using System.Numerics;
using MeetingNotes.Services;
using Microsoft.AspNetCore.Identity;
using MeetingNotes.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeetingNotes.Services
{
    public interface IWorkerService
    {
        Worker? GetWorkerById(int id);
        int CreateWorker(Worker worker);
        IEnumerable<Worker> GetWorkers();
        Task DeleteWorkerAsync(int id);

        Task<int> EditWorkerAsync(Worker worker);
        Task<int> CreateWorkerModel(CreateWorkerModel model);
    }
    public class WorkerServices : IWorkerService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public WorkerServices(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public Worker? GetWorkerById(int id)
        {
            var worker = _db.Workers.Where(w => w.WorkerId == id).Include(s => s.IdentityUser).AsNoTracking().FirstOrDefault();//firstordefault se brine da vrati null ako nema npr nekog workera sa odredenim id
            return worker;
        }
        public int CreateWorker(Worker worker)
        {
            var user = new IdentityUser();//popunit njega 
            _db.Workers.Add(worker);
            _db.SaveChanges();
            if (worker.IsManager == true)
            {
                var manager = new Manager();
                manager.WorkerId = worker.WorkerId;
                _db.Managers.Add(manager);
                _db.SaveChanges();
            }
            return worker.WorkerId;
        }

        public async Task<int> CreateWorkerModel(CreateWorkerModel model)
        {
            var user = new IdentityUser();
            user.UserName = model.Email;
            user.Email = model.Email;
            user.NormalizedEmail = model.Email.ToUpper();
            user.NormalizedUserName = model.Username.ToUpper();
            user.EmailConfirmed = true;
            var password=model.Password;

            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            user.PasswordHash = ph.HashPassword(user, password);

            var result = await _userManager.CreateAsync(user);

            if (model.IsManager == true)
            {
                await _userManager.AddToRoleAsync(user, "Manager");
                await _userManager.AddToRoleAsync(user, "Worker");//manager mora imat obje role
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Worker");
            }

            var worker = new Worker();
            worker.LastName = model.LastName;
            worker.FirstName = model.FirstName;
            worker.EnrollmentDate = model.EnrollmentDate;
            worker.IsManager = model.IsManager;
            worker.IdentityUser = user;

            _db.Workers.Add(worker);
            _db.SaveChanges();

            return worker.WorkerId;
        }




        public async Task DeleteWorkerAsync(int id)
        {
            var worker = _db.Workers.Where(w => w.WorkerId == id).Include(s => s.IdentityUser).AsNoTracking().FirstOrDefault();
            var identity = new IdentityUser();
            identity = worker.IdentityUser;
            await _userManager.DeleteAsync(identity);
            _db.Workers.Remove(worker);
            _db.SaveChanges();
            //if (worker.IsManager == true)
            //{
            //    var manager = _db.Managers.Where(w => w.WorkerId == worker.WorkerId).FirstOrDefault();
            //    _db.Managers.Remove(manager);
            //    _db.SaveChanges();
            //}
        }

        public async Task<int> EditWorkerAsync(Worker worker)
        {
            //var worker = _db.Workers.Where(w => w.WorkerId == id).FirstOrDefault();
            //if (worker.IsManager == false)
            //{
            //    var manager = _db.Managers.Where(w => w.WorkerId == worker.WorkerId).FirstOrDefault();
            //    _db.Managers.Remove(manager);
            //    _db.SaveChanges();
            //}


            //if (worker.IsManager == true)
            //{
            //    var manager = new Manager();
            //    //var manager = _db.Managers.Where(w => w.WorkerId == worker.WorkerId).FirstOrDefault();
            //    manager.WorkerId = worker.WorkerId;
            //    _db.Managers.Add(manager);
            //    _db.SaveChanges();
            //}


            //var identity = new IdentityUser();
            //identity = worker.IdentityUser;
            //await _userManager.UpdateAsync(identity); ne smijemo editat username i email!!!
            _db.Workers.Update(worker);
            _db.SaveChanges();
            return worker.WorkerId;
        }
        public IEnumerable<Worker> GetWorkers()
        {
            return _db.Workers.ToList();
        }
    }
}
