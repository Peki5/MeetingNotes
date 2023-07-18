using MeetingNotes.Data;
using MeetingNotes.Models;
using MeetingNotes.Models.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace MeetingNotes.Services
{
    public interface IMeetingService
    {
        Meeting? GetMeetingById(int id);

        int CreateMeeting(Meeting meeting);

        IEnumerable<Meeting> GetMeetings();

        void DeleteMeeting(int id);

        int EditMeeting(Meeting meeting);

        IEnumerable<MeetingViewModel> GetAllMeetingsViewModel();

    }

    public class MeetingServices : IMeetingService
    {
        private readonly ApplicationDbContext _db;

        public MeetingServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public Meeting? GetMeetingById(int id)
        {
            var meeting = _db.Meetings.Where(w => w.MeetingId == id).Include(s => s.notes).AsNoTracking().FirstOrDefault();
            return meeting;
        }

        public IEnumerable<MeetingViewModel> GetAllMeetingsViewModel()
        {
            var result = _db.Meetings.Select(s => new MeetingViewModel
            {
                MeetingId = s.MeetingId,
                MeetingDate = s.MeetingDate,
                ManagerFullName = _db.Workers.Where(w => w.WorkerId == s.ManagerId).Select(s => s.FirstName + " " + s.LastName).FirstOrDefault(),
                WorkerFullName = _db.Workers.Where(w => w.WorkerId == s.WorkerId).Select(s => s.FirstName + " " + s.LastName).FirstOrDefault()
            }).ToList();

            return result;
        }

        public int CreateMeeting(Meeting meeting)
        {
            _db.Meetings.Add(meeting);
            _db.SaveChanges();
            return meeting.MeetingId;
        }
        public IEnumerable<Meeting> GetMeetings()
        {
            return _db.Meetings.ToList();
        }

        public void DeleteMeeting(int id)
        {
            var meeting = GetMeetingById(id);
            _db.Meetings.Remove(meeting);
            _db.SaveChanges();
        }

        public int EditMeeting(Meeting meeting)
        {
            _db.Meetings.Update(meeting);
            _db.SaveChanges();
            return meeting.MeetingId;
        }
    }
}
