namespace MeetingNotes.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }//ovo je zapravo WorkerId jer je manager zapravo worker

        public ICollection<Worker> Workers { get; set; }
    }
}
