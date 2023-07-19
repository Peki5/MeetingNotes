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
        void DeleteWorker(int id);

        int EditWorker(Worker worker);
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
            user.UserName = model.Username;
            user.Email = model.Email;
            user.NormalizedEmail = model.Email.ToUpper();
            user.NormalizedUserName = model.Username.ToUpper();

            var result = await _userManager.CreateAsync(user);

            if (model.IsManager == true)
            {
                var result2 = await _userManager.AddToRoleAsync(user, "Manager");
            }
            else
            {
                var result2 = await _userManager.AddToRoleAsync(user, "Worker");
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




        public void DeleteWorker(int id)
        {
            var worker = _db.Workers.Where(w => w.WorkerId == id).FirstOrDefault();
            _db.Workers.Remove(worker);
            _db.SaveChanges();
            if (worker.IsManager == true)
            {
                var manager = _db.Managers.Where(w => w.WorkerId == worker.WorkerId).FirstOrDefault();
                _db.Managers.Remove(manager);
                _db.SaveChanges();
            }
        }

        public int EditWorker(Worker worker)
        {
            //var worker = _db.Workers.Where(w => w.WorkerId == id).FirstOrDefault();
            //if (worker.IsManager == false)
            //{
            //    var manager = _db.Managers.Where(w => w.WorkerId == worker.WorkerId).FirstOrDefault();
            //    _db.Managers.Remove(manager);
            //    _db.SaveChanges();
            //}
            if (worker.IsManager == true)
            {
                var manager = new Manager();
                //var manager = _db.Managers.Where(w => w.WorkerId == worker.WorkerId).FirstOrDefault();
                manager.WorkerId = worker.WorkerId;
                _db.Managers.Add(manager);
                _db.SaveChanges();
            }
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
