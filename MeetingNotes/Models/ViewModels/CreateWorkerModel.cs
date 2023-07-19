using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MeetingNotes.Models.ViewModels
{
    public class CreateWorkerModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsManager { get; set; }
        public string Username { get; set; }    
        public string Email { get; set; }
        public string Password { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
    }
}
