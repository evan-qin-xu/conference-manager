using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ConferenceManager.Data;

namespace ConferenceManager.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<ConferenceManagerContext>
    {
        protected override void Seed(ConferenceManagerContext context)
        {
            // Create list of conference objects
            var conferences = new List<Conference>()
            {
                new Conference()
                {
                    ConferenceTitle = "Machine Learning in Adaptive Systems",
                    Location = "23 Oxford St, Sydney NSW 2000, Australia",
                    ConferenceTime = new DateTime(2021, 11, 02, 09, 00, 00)
                },

                new Conference()
                {
                    ConferenceTitle = "Cloud Computing in Systems Development",
                    Location = "100 Broadway St, Sydney NSW 2000, Australia",
                    ConferenceTime = new DateTime(2022, 01, 02, 09, 00, 00)
                },
                
                new Conference()
                {
                    ConferenceTitle = "Artificial Intelligence in User Modeling",
                    Location = "25 Darcy St, Melbourne VIC 2000, Australia",
                    ConferenceTime = new DateTime(2021, 09, 01, 09, 00, 00)
                }

            };

            // Create list of participant objects
            var participants = new List<Participant>()
            {
                new Participant()
                {
                    FullName = "Adam Goodman",
                    Email = "JasonGoodman@gmail.com",
                    Phone = "07-7991-8880",
                    Address = "56 Waterloo Rd, Sydney NSW2000, Australia"
                },

                new Participant()
                {
                FullName = "John Hallo",
                Email = "JohnHallo@hotmail.com",
                Phone = "07-7991-9990",
                Address = "12 Catalina Rd, Melbourne VIC2000, Australia"
                },

                new Participant() 
                {
                    FullName = "Sarah Johnson",
                    Email = "SarahJohnson@hotmail.com",
                    Phone = "07-3467-9290",
                    Address = "3 Academy Rd, Brisbane QLD 2000, Australia"
                }
            };

            // Create list of registration objects
            var registrations = new List<Registration>
            {
                new Registration()
                {
                    ParticipantId = 1,
                    ConferenceId = 2,
                    RegistrationTime = new DateTime(2020, 05, 05, 11, 53, 23)
                },

                new Registration()
                {
                    ParticipantId = 2,
                    ConferenceId = 3,
                    RegistrationTime = new DateTime(2020, 06, 30, 09, 23, 11)
                },

                new Registration()
                {
                    ParticipantId = 3,
                    ConferenceId = 1,
                    RegistrationTime = new DateTime(2020, 04, 12, 13, 34, 25)
                }
            };

            // Seed the database with created objects
            foreach (var conference in conferences)
            {
                context.Conferences.Add(conference);
            }

            foreach (var participant in participants)
            {
                context.Participants.Add(participant);
            }

            foreach (var registration in registrations)
            {
                context.Registrations.Add(registration);
            }

            base.Seed(context);
        }
    }
}