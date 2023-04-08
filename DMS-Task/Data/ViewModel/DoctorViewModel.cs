using DMS_Task.Models;

namespace DMS_Task.Data.ViewModel
{
    public class DoctorViewModel
    {
        public Doctor Doctor { get; set; }
        public List<PatientAppointment> PatientAppointments { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
