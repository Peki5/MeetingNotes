using MeetingNotes.Data;
using MeetingNotes.Models;
using System.Numerics;

namespace MeetingNotes.Services
{
    public interface IWorkerService
    {
        Worker? GetWorkerById (int id);
        int CreateWorker(Worker worker);
        public IEnumerable<Worker> GetWorkers();
    }
    public class WorkerServices : IWorkerService
    {
        private readonly ApplicationDbContext _db;
        public WorkerServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public Worker? GetWorkerById(int id)
        {
            var worker= _db.Workers.Where(w => w.Id==id).FirstOrDefault();//firstordefault se brine da vrati null ako nema npr nekog workera sa odredenim id
            return worker;
        }
        public int CreateWorker(Worker worker)
        {
            _db.Workers.Add(worker);
            _db.SaveChanges();
            return worker.Id;
        }
        public IEnumerable<Worker> GetWorkers() 
        {
            return _db.Workers.ToList();
        }
    }
}
