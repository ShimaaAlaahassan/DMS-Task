using DMS_Task.Data;
using DMS_Task.Data.VewModel;
using DMS_Task.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DMS_Task.Controllers
{
	public class SecretaryController : Controller
	{
		
		ApplicationDbContext db;
		public SecretaryController(ApplicationDbContext db)
		{
			this.db = db;
		}
		//get all patient appointment 
		public IActionResult GetAllAppointment()
		{
			List<PatientAppointment> patients = db.PatientsAppointment.ToList();
			return View(patients);
		}
		
		// add new appointment 
		public IActionResult Create()
		{
			var viewModel = new AppointmentViewModel();
			viewModel.AppointmentDate = DateTime.Today.Date; 
			viewModel.PatientBirthDate = DateTime.Today.Date;
			InitCreateActionViewBag();

            return View(viewModel);
		}

        // to save new appointment in database 
        [HttpPost]
		public IActionResult Create(AppointmentViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				if (DoctorExistORNot(viewModel.DoctorId, viewModel.AppointmentDate))
				{
					bool dataexist = db.PatientsAppointment.Any(a => a.AppointmentDate == viewModel.AppointmentDate && a.StartTime == viewModel.StartTime);
					if (dataexist == true)
					{
						ModelState.AddModelError(string.Empty, "This appointment is not available");
					}
					else
					{
						//time interval
                        TimeSpan interval = TimeSpan.FromMinutes(30);

                        var appointment = new PatientAppointment();
						appointment.FName = viewModel.PatientFName; 
						appointment.LName = viewModel.PatientLName;
						appointment.BirthDate = viewModel.PatientBirthDate;
						appointment.DoctorID = viewModel.DoctorId;
						appointment.AppointmentDate = viewModel.AppointmentDate;
						appointment.StartTime = viewModel.StartTime;
						appointment.EndTime = viewModel.StartTime + interval;

                        appointment.VisitLength = viewModel.VisitLength;



						// Save the new appointment to the database
						db.PatientsAppointment.Add(appointment);
						db.SaveChanges();

						return RedirectToAction("Index");
					}
				}
				else
				{
					ModelState.AddModelError(string.Empty, "This Doctor is not available");

				}
			}

			InitCreateActionViewBag();
			return View(viewModel);
		}

		private void InitCreateActionViewBag()
		{
            ViewBag.DoctorList = new SelectList(db.Doctors, "Id", "name");
            var timeSlots = GetTimeSlots().Select(dt => new { Value = dt.ToString("HH:mm:ss"), Text = dt.ToString("HH:mm") });
            ViewBag.SlotTime = new SelectList(timeSlots, "Value", "Text");
        }

		private bool DoctorExistORNot(int id, DateTime day)
		{
			return db.Schedules.Any(s => s.Doctor.Id == id && s.Day == day);
		}
		private List<DateTime> GetTimeSlots()
		{
            TimeSpan startTime = TimeSpan.Parse("12:00");
            TimeSpan endTime = TimeSpan.Parse("23:00");
            TimeSpan interval = TimeSpan.FromMinutes(30);

            List<DateTime> timeSlots = new List<DateTime>();

            for (TimeSpan time = startTime; time < endTime; time += interval)
            {
                DateTime dateTime = DateTime.Now.Date.Add(time);
                timeSlots.Add(dateTime);
            }
			return timeSlots;
        }
}
	}
