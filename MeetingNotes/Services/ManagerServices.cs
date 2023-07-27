using MeetingNotes.Data;
using MeetingNotes.Models;
using System.Numerics;
using MeetingNotes.Services;
using Microsoft.AspNetCore.Identity;
using MeetingNotes.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeetingManager.Services
{
    public interface IManagerService
    {
        Manager? GetManagerById(int id);

        int CreateManager(Manager manager);

        IEnumerable<Manager> GetManagers();

        void DeleteManager(int id);

        int EditManager(Manager manager);

        ManagerWorkerPairingModel GetAllManagersViewModel();

        Task<int> CreateManagerModel(CreateManagerModel model);
    }

    public class ManagerServices : IManagerService
    {
        private readonly ApplicationDbContext _db;

        public ManagerServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public Manager? GetManagerById(int id)
        {
            var manager = _db.Managers.Where(w => w.ManagerId == id).FirstOrDefault();
            return manager;
        }
        public int CreateManager(Manager manager)
        {
            _db.Managers.Add(manager);
            _db.SaveChanges();
            return manager.ManagerId;
        }
        public IEnumerable<Manager> GetManagers()
        {
            return _db.Managers.ToList();
        }

        public void DeleteManager(int id)
        {
            var manager = GetManagerById(id);
            _db.Managers.Remove(manager);
            _db.SaveChanges();
        }

        public int EditManager(Manager manager)
        {
            _db.Managers.Update(manager);
            _db.SaveChanges();
            return manager.ManagerId;
        }

        public ManagerWorkerPairingModel GetAllManagersViewModel()
        {
            var workers = _db.Workers.Select(s => new WorkerSelectionViewModel
            {
                Id = s.WorkerId,
                FullName = s.FirstName + " " + s.LastName
            }).ToList();

            var managers = _db.Workers.Where(w=>w.IsManager==true).Select(s => new WorkerSelectionViewModel
            {
                Id = s.WorkerId,
                FullName = s.FirstName + " " + s.LastName
            }).ToList();

            var viewModel = new ManagerWorkerPairingModel
            {
                Managers = managers,
                Workers = workers,
            };

            return viewModel;
        }

        public async Task<int> CreateManagerModel(CreateManagerModel model)
        {
            try
            {


                // Process the data and save it to your data source
                // Create a list of Manager entities based on the selected WorkerIds
                List<Manager> managers = model.SelectedWorkerIds.Select(workerId => new Manager
                {
                    ManagerId = model.SelectedManagerId,
                    WorkerId = workerId
                }).ToList();


                // Save the managers to the database
                foreach (var manager in managers)
                {
                    _db.Managers.Add(manager);
                    _db.SaveChanges();
                }
                // Redirect to a different page after successful creation

                return model.SelectedManagerId;
            }
            catch (Exception ex) {
                return 0;
            }

            
        }
    }
}
