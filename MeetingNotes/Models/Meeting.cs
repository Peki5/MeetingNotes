using System.ComponentModel.DataAnnotations;

namespace MeetingNotes.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }

        public DateOnly MeetingDate { get; set; }

        public int ManagerId;
        public int WorkerId;
        public int NotesId;

    }
}
