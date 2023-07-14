using System.ComponentModel.DataAnnotations;

namespace MeetingNotes.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }

        public DateTime MeetingDate { get; set; }

        public int ManagerId;
        public int WorkerId;

        public Notes notes { get; set; }

    }
}
