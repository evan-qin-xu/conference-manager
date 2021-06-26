using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Printing;
using System.Linq;
using System.Web;

namespace ConferenceManager.Models
{
    public class Attendee : Participant
    {

        [Display(Name = "Professional Title")]
        public ProfessionalTitles? ProfessionalTitle { get; set; }

        public virtual IList<Registration> Registrations { get; set; }

        public enum ProfessionalTitles
        {
            [Description("Professor")] Professor = 1,
            [Description("Associate Professor")] AssociateProfessor = 2,
            [Description("Assistant Professor")] AssistantProfessor = 3,
            [Description("Instructor")] Instructor = 4
        }
    }
}