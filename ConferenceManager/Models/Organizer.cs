using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace ConferenceManager.Models
{
    public class Organizer : Participant
    {
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        public virtual IList<Registration> Registrations { get; set; }
    }
}