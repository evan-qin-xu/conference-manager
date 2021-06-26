using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ConferenceManager.Models
{
    public class Participant
    {
        public int ParticipantId { get; set; }

        [Required(ErrorMessage = "Participant's full name is required.")]
        [StringLength(60, ErrorMessage = "Full name must be within {0} characters.")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}