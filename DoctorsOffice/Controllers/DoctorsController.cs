using DoctorsOffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DoctorsOffice.Controllers
{
  public class DoctorsController: Controller
  {
    private readonly DoctorsOfficeContext _db;

    public DoctorsController(DoctorsOfficeContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Doctors.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PatientId = new SelectList(_db.Patients, "PatientId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Doctor doctor, int PatientId)
    {
      _db.Doctors.Add(doctor);
      _db.SaveChanges();
      if (PatientId != 0)
      {
        _db.DoctorPatients.Add(new DoctorPatient() {PatientId = PatientId, DoctorId = doctor.DoctorId});
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Doctor foundDoctor = _db.Doctors
        .Include(doctor => doctor.JoinEntities)
        .ThenInclude(join => join.Patient)
        .FirstOrDefault(model => model.DoctorId == id);
      return View(foundDoctor);
    }
  }
}