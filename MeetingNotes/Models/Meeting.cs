using System.ComponentModel.DataAnnotations;

namespace MeetingNotes.Models
{
    public class Meeting
    {
        public int MeetingId { get; set; }

        public DateTime MeetingDate { get; set; }
        [Required]
        public int ManagerId { get; set; }
        [Required]
        public int WorkerId { get; set; }
        public Notes notes { get; set; }

        //navigacija na drugu tablicu da bi mogli preko id dohvacat workere 


    }
}
