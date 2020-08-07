using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CTMS.Models;
using Microsoft.AspNet.Identity;

namespace CTMS.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.City).Include(p => p.Governorate);
            return View(patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details()
        {
            var userId = User.Identity.GetUserId();
            
            var patient = db.Patients.SingleOrDefault(p => p.Patient_Id == userId);
            var GovId = patient.GovernorateId;
            var CityId = patient.CityId;
            ViewBag.CountryName = db.Governorates.SingleOrDefault(g => g.Id == GovId);
            ViewBag.CityName = db.Cities.SingleOrDefault(c => c.Id ==CityId);


            return View(patient);
        }

       
        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name");
            //ViewBag.Patient_Id = new SelectList(db.ApplicationUsers, "Id", "Name");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Gender,BirthDate,Height,Weight,BloodType,Phone,Address,PatientEmail,GovernorateId,CityId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", patient.CityId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name", patient.GovernorateId);
            //ViewBag.Patient_Id = new SelectList(db.ApplicationUsers, "Id", "Name", patient.Patient_Id);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", patient.CityId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name", patient.GovernorateId);
            //ViewBag.Patient_Id = new SelectList(db.ApplicationUsers, "Id", "Name", patient.Patient_Id);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,BirthDate,Height,Weight,BloodType,Phone,Address,PatientEmail,GovernorateId,CityId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PatientLayOut","Home");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", patient.CityId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name", patient.GovernorateId);
            //ViewBag.Patient_Id = new SelectList(db.ApplicationUsers, "Id", "Name", patient.Patient_Id);
            return View(patient);
        }

        /********************/
        // GET: Patients/Edit/5
        public ActionResult Complete()
        {
            var userId = User.Identity.GetUserId();

            var patient = db.Patients.SingleOrDefault(p => p.Patient_Id == userId);

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", patient.CityId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name", patient.GovernorateId);
            //ViewBag.Patient_Id = new SelectList(db.ApplicationUsers, "Id", "Name", patient.Patient_Id);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complete([Bind(Include = "Id,Name,Gender,BirthDate,Height,Weight,BloodType,Phone,Address,PatientEmail,GovernorateId,CityId")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PatientLayOut", "Home");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", patient.CityId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name", patient.GovernorateId);
            //ViewBag.Patient_Id = new SelectList(db.ApplicationUsers, "Id", "Name", patient.Patient_Id);
            return View(patient);
        }

/**************************************************************************************/

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
