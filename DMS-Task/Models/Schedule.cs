using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DMS_Task.Models
{
	public class Schedule
	{
		[Key]
		public int ID { get; set; }
		
		public TimeSpan StartTime { get; set; }
      
        public TimeSpan EndTime { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Day { get; set; }
        [ForeignKey("Doctor")]
        public int DoctorID { get; set; }
        public virtual Doctor? Doctor { get; set; }

    }
}
