using System.ComponentModel.DataAnnotations;

namespace DMS_Task.Data.VewModel
{
	public class AppointmentViewModel
	{

		public string? PatientFName { get; set; }
		public string? PatientLName { get; set; }
		[Required(ErrorMessage = "The PatientBirthDate field is required.")]
        
        public DateTime PatientBirthDate { get; set; }
		public int DoctorId { get; set; }
		[Required]
        
        public DateTime AppointmentDate { get; set; }
       
        [Required(ErrorMessage = "The StartTime field is required.")]
        public TimeSpan StartTime { get; set; }
        //[Required(ErrorMessage = "The EndTime field is required.")]
        public TimeSpan EndTime { get; set; }
        public int VisitLength { get; set; } = 30;
	}
}
