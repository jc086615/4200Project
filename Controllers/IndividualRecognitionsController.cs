using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _4200Project.DAL;
using _4200Project.Models;

namespace _4200Project.Controllers
{
    public class IndividualRecognitionsController : Controller
    {
        private Context db = new Context();

        // GET: IndividualRecognitions
        public ActionResult Index()
        {
            var individualRecognitions = db.IndividualRecognitions.Include(i => i.Employee);
            return View(individualRecognitions.ToList());
        }

        // GET: IndividualRecognitions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualRecognition individualRecognition = db.IndividualRecognitions.Find(id);
            if (individualRecognition == null)
            {
                return HttpNotFound();
            }
            return View(individualRecognition);
        }

        // GET: IndividualRecognitions/Create
        public ActionResult Create()
        {
            ViewBag.EID = new SelectList(db.Employees, "EID", "FirstName");
            return View();
        }

        // POST: IndividualRecognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecognitionID,EID,DateOfRecognition,award,Comments")] IndividualRecognition individualRecognition)
        {
            if (ModelState.IsValid)
            {
                db.IndividualRecognitions.Add(individualRecognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EID = new SelectList(db.Employees, "EID", "FirstName", individualRecognition.EID);
            return View(individualRecognition);
        }

        // GET: IndividualRecognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualRecognition individualRecognition = db.IndividualRecognitions.Find(id);
            if (individualRecognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.EID = new SelectList(db.Employees, "EID", "FirstName", individualRecognition.EID);
            return View(individualRecognition);
        }

        // POST: IndividualRecognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecognitionID,EID,DateOfRecognition,award,Comments")] IndividualRecognition individualRecognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(individualRecognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EID = new SelectList(db.Employees, "EID", "FirstName", individualRecognition.EID);
            return View(individualRecognition);
        }

        // GET: IndividualRecognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IndividualRecognition individualRecognition = db.IndividualRecognitions.Find(id);
            if (individualRecognition == null)
            {
                return HttpNotFound();
            }
            return View(individualRecognition);
        }

        // POST: IndividualRecognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IndividualRecognition individualRecognition = db.IndividualRecognitions.Find(id);
            db.IndividualRecognitions.Remove(individualRecognition);
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
