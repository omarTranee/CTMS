using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CTMS.Models;

namespace CTMS.Controllers
{
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctors
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.City).Include(d => d.Governorate).Include(d => d.Physician).Include(d => d.Speciality);
            return View(doctors.ToList());
        }

        // GET: Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name");
            //ViewBag.PhysicianId = new SelectList(db.ApplicationUsers, "Id", "Name");
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DoctorImage,Name,Gender,Phone,Address,Price,DoctorInformation,SpecialityId,PhysicianId,CityId,GovernorateId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", doctor.CityId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name", doctor.GovernorateId);
            //ViewBag.PhysicianId = new SelectList(db.ApplicationUsers, "Id", "Name", doctor.PhysicianId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", doctor.SpecialityId);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", doctor.CityId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name", doctor.GovernorateId);
            //ViewBag.PhysicianId = new SelectList(db.ApplicationUsers, "Id", "Name", doctor.PhysicianId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", doctor.SpecialityId);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DoctorImage,Name,Gender,Phone,Address,Price,DoctorInformation,SpecialityId,PhysicianId,CityId,GovernorateId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", doctor.CityId);
            ViewBag.GovernorateId = new SelectList(db.Governorates, "Id", "Name", doctor.GovernorateId);
            //ViewBag.PhysicianId = new SelectList(db.ApplicationUsers, "Id", "Name", doctor.PhysicianId);
            ViewBag.SpecialityId = new SelectList(db.Specialities, "Id", "Name", doctor.SpecialityId);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
