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
    public class RecognitionsController : Controller
    {
        private Context db = new Context();

        // GET: Recognitions
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(db.Recognitions.ToList());
            }
            else
            {
                return View("NotAuthenticated");
            }
        }
        public ActionResult MyChart()
        {
            decimal Excellence = 0;
            decimal Culture = 0;
            decimal Stewardship = 0;
            decimal Integrity = 0;
            decimal Innovate = 0;
            decimal Passion = 0;
            decimal Balance = 0;
            new System.Web.Helpers.Chart(width: 800, height: 200)

            .AddSeries(
                chartType: "column",
                xValue: new[] { "Excellence", "Culture", "Stewardship", "Integrity", "Innovate", "Passion", "Balance" },
                yValues: new[] { Excellence, Culture, Stewardship, Integrity, Innovate, Passion, Balance })
            .Write("png");
            return null;
        }       
        
        // GET: Recognitions/Details/5
        public ActionResult Details(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // GET: Recognitions/Create
        public ActionResult Create()
        {
            ViewBag.EID = new SelectList(db.Employees, "EID", "FullName");
            return View();
        }

        // POST: Recognitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecognitionID,EID,DateOfRecognition,award,Comments")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Recognitions.Add(recognition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EID = new SelectList(db.Employees, "EID", "FirstName", recognition.EID);
            return View(recognition);
        }

        // GET: Recognitions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            ViewBag.EID = new SelectList(db.Employees, "EID", "FirstName", recognition.EID);
            return View(recognition);
        }

        // POST: Recognitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecognitionID,EID,DateOfRecognition,award,Comments")] Recognition recognition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recognition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EID = new SelectList(db.Employees, "EID", "FirstName", recognition.EID);
            return View(recognition);
        }

        // GET: Recognitions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recognition recognition = db.Recognitions.Find(id);
            if (recognition == null)
            {
                return HttpNotFound();
            }
            return View(recognition);
        }

        // POST: Recognitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recognition recognition = db.Recognitions.Find(id);
            db.Recognitions.Remove(recognition);
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
