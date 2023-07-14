using MeetingNotes.Data;
using MeetingNotes.Models;
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
            var meeting = _db.Meetings.Where(w=>w.MeetingId==id).Include(s=>s.notes).AsNoTracking().FirstOrDefault();
            return meeting;
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
