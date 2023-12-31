﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using System.Drawing;

namespace MeetingNotes.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsManager { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }
    
        //public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; } 

    }
}

    
