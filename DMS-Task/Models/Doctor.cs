using System.ComponentModel.DataAnnotations;

namespace DMS_Task.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public string? name { get; set; }
        public string? Specialize { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public virtual List<PatientAppointment> Patients { get; set; } = new List<PatientAppointment>();
        public virtual List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
