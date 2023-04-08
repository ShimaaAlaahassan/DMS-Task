using DMS_Task.Data;
using DMS_Task.Data.ViewModel;
using DMS_Task.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;

namespace DMS_Task.Controllers
{
	public class DoctorsController : Controller
	{
		ApplicationDbContext db;
       
        public DoctorsController(ApplicationDbContext db)
		{
			this.db = db;
		}
		//to see all doctors
		public IActionResult GetAll()
		{
			List<Doctor> doctors = db.Doctors.ToList();
			return View(doctors);
		}
		//to see one doctor and their appointment today 
		public IActionResult Details(int id)
		{
            string? startDate = Request.Query["startDate"];
            string? endDate = Request.Query["endDate"];
            //get the info about the doctor 
            Doctor? doctor = db.Doctors.SingleOrDefault(q => q.Id == id);
			List<PatientAppointment> appointment;

            if (startDate == null && endDate == null)
			{
				//pass doctor and his appointment to the view 
				 appointment = db.PatientsAppointment.Where(a => a.DoctorID == doctor.Id && a.AppointmentDate.Date == DateTime.Today).ToList();
			}
			else
			{
				appointment = db.PatientsAppointment.Where(a => a.Doctor.Id == id && a.AppointmentDate >= DateTime.Parse(startDate) && a.AppointmentDate <= DateTime.Parse(endDate)).ToList();
			}
			return View( new DoctorViewModel { Doctor = doctor, PatientAppointments = appointment });

        }
		

    }
}
