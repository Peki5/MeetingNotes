namespace MeetingNotes.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }//ovo je zapravo worker id

        public ICollection<Worker> Workers { get; set; }
    }
}
