using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ConferenceManager.Data;
using ConferenceManager.Models;

namespace ConferenceManager.Controllers
{
    public class RegistrationsController : Controller
    {
        private ConferenceManagerContext db = new ConferenceManagerContext();

        // GET: Registrations
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "titleDescending" : "";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) || sortOrder == "nameAscending" ? "nameDescending" : "nameAscending";

            var registrations = db.Registrations.Include(r => r.Conference).Include(r => r.Participant);
            
            // Default list is order by conference title
            registrations = registrations.OrderBy(r => r.Conference.ConferenceTitle);

            // Filter registration record based on searchString
            if (!String.IsNullOrEmpty(searchString))
            {
                
                searchString = searchString.ToLower();
                registrations = registrations.Where(r => r.Conference.ConferenceTitle.ToLower().Contains(searchString) || r.Participant.FullName.ToLower().Contains(searchString));
            }

            // Sort the registration record based on properties
            if (sortOrder == "titleDescending")
                registrations = registrations.OrderByDescending(r => r.Conference.ConferenceTitle);
            else if (sortOrder == "nameDescending")
                registrations = registrations.OrderByDescending(r => r.Participant.FullName);
            else if (sortOrder == "nameAscending")
                registrations = registrations.OrderBy(r => r.Participant.FullName);
            
            return View(registrations.ToList());
        }

        // GET: Registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: Registrations/Create
        public ActionResult Create()
        {
            ViewBag.ConferenceId = new SelectList(db.Conferences, "ConferenceId", "ConferenceTitle");
            ViewBag.ParticipantId = new SelectList(db.Participants, "ParticipantId", "FullName");
            return View();
        }

        // POST: Registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistrationId,ParticipantId,ConferenceId,RegistrationTime")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Registrations.Add(registration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConferenceId = new SelectList(db.Conferences, "ConferenceId", "ConferenceTitle", registration.ConferenceId);
            ViewBag.ParticipantId = new SelectList(db.Participants, "ParticipantId", "FullName", registration.ParticipantId);
            return View(registration);
        }

        // GET: Registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConferenceId = new SelectList(db.Conferences, "ConferenceId", "ConferenceTitle", registration.ConferenceId);
            ViewBag.ParticipantId = new SelectList(db.Participants, "ParticipantId", "FullName", registration.ParticipantId);
            return View(registration);
        }

        // POST: Registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistrationId,ParticipantId,ConferenceId,RegistrationTime")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConferenceId = new SelectList(db.Conferences, "ConferenceId", "ConferenceTitle", registration.ConferenceId);
            ViewBag.ParticipantId = new SelectList(db.Participants, "ParticipantId", "FullName", registration.ParticipantId);
            return View(registration);
        }

        // GET: Registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration registration = db.Registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: Registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration registration = db.Registrations.Find(id);
            db.Registrations.Remove(registration);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
