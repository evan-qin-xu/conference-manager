using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ConferenceManager.Models
{
    public class Registration
    {
        
        public int RegistrationId { get; set; }

        [Display(Name = "Participant")]
        public int ParticipantId { get; set; }

        [Display(Name = "Conference")]
        public int ConferenceId { get; set; }

        [Required]
        public DateTime RegistrationTime { get; set; }

        public Participant Participant { get; set; }
        public Conference Conference { get; set; }
    }
}