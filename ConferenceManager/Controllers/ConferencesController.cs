using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConferenceManager.Data;
using ConferenceManager.Models;

namespace ConferenceManager.Controllers
{
    public class ConferencesController : Controller
    {
        private ConferenceManagerContext db = new ConferenceManagerContext();

        // GET: Conferences base on params passed by view
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "titleDescending" : "";
            ViewBag.DateSortParm = sortOrder == "date" ? "dateDescending" : "date";

            var conferences = from c in db.Conferences select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                conferences = conferences.Where(c => c.ConferenceTitle.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "titleDescending":
                    conferences = conferences.OrderByDescending(c => c.ConferenceTitle);
                    break;
                case "date":
                    conferences = conferences.OrderBy(c => c.ConferenceTime);
                    break;
                case "dateDescending":
                    conferences = conferences.OrderByDescending(c => c.ConferenceTime);
                    break;
                default:
                    conferences = conferences.OrderBy(c => c.ConferenceTitle);
                    break;
            }

            return View(conferences.ToList());
        }

        // GET: Conferences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conference conference = db.Conferences.Find(id);
            if (conference == null)
            {
                return HttpNotFound();
            }
            return View(conference);
        }

        // GET: Conferences/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Conferences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConferenceId,ConferenceTitle,Location,ConferenceTime")] Conference conference)
        {
            if (ModelState.IsValid)
            {
                db.Conferences.Add(conference);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conference);
        }

        // GET: Conferences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conference conference = db.Conferences.Find(id);
            if (conference == null)
            {
                return HttpNotFound();
            }
            return View(conference);
        }

        // POST: Conferences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConferenceId,ConferenceTitle,Location,ConferenceTime")] Conference conference)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conference).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conference);
        }

        // GET: Conferences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Conference conference = db.Conferences.Find(id);
            if (conference == null)
            {
                return HttpNotFound();
            }
            return View(conference);
        }

        // POST: Conferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Conference conference = db.Conferences.Find(id);
            db.Conferences.Remove(conference);
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
