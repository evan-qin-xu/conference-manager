using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace ConferenceManager.Models
{
    public class Conference
    {
        public int ConferenceId { get; set; }

        [Required]
        [Display(Name="Conference Title")]
        public string ConferenceTitle { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        [Display(Name="Conference Time")]
        public DateTime ConferenceTime { get; set; }

        public IList<Registration> Registrations { get; set; }
    }
}