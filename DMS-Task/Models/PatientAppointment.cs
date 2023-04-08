using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS_Task.Models
{
	public class PatientAppointment
	{
		[Key]
		public int Id { get; set; }
		public string? FName { get; set; }
		public string? LName { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime AppointmentDate { get;set; }
        
        // public DateTime AppointmentTime { get; set; }
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public int VisitLength { get; set; } = 30;
		//relationship
		//[ForeignKey("Secratery")]
		//public int SectateryID { get; set; }
		//public virtual Secratery? Secratery { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }



    }
}
